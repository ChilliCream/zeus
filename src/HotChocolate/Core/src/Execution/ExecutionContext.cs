using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.ObjectPool;
using HotChocolate.Execution.Utilities;
using HotChocolate.Fetching;

namespace HotChocolate.Execution
{
    internal partial class ExecutionContext
        : IExecutionContext
    {
        public ITaskBacklog TaskBacklog => _taskBacklog;

        public ITaskStatistics TaskStats => _taskStatistics;

        public bool IsCompleted => TaskStats.IsCompleted;

        public ObjectPool<ResolverTask> TaskPool { get; }

        public IBatchDispatcher BatchDispatcher { get; private set; } = default!;

        private void SetEngineState()
        {
            if (TaskStats.NewTasks == 0 && BatchDispatcher.HasTasks)
            {
                BatchDispatcher.Dispatch();
            }

            if (TaskStats.IsCompleted)
            {
                _channel.Writer.TryComplete();
            }
        }

        private void BatchDispatcherEventHandler(
            object? source, EventArgs args)
        {
            lock (_taskStatistics.SyncRoot)
            {
                SetEngineState();
            }
        }

        private void TaskStatisticsEventHandler(
            object? source, EventArgs args) =>
            SetEngineState();
    }
}
