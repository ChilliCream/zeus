using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Execution.Configuration;

namespace HotChocolate.Execution
{
    internal sealed class RequestTimeoutMiddleware
    {
        private const int _debuggerTimeoutInMinutes = 30;
        private readonly QueryDelegate _next;
        private readonly IErrorHandler _errorHandler;
        private readonly IRequestTimeoutOptionsAccessor _options;

        public RequestTimeoutMiddleware(
            QueryDelegate next,
            IErrorHandler errorHandler,
            IRequestTimeoutOptionsAccessor options)
        {
            _next = next
                ?? throw new ArgumentNullException(nameof(next));
            _errorHandler = errorHandler
                ?? throw new ArgumentNullException(nameof(errorHandler));
            _options = options ??
                throw new ArgumentNullException(nameof(options));
        }

        public async Task InvokeAsync(IQueryContext context)
        {
            TimeSpan timeout = Debugger.IsAttached
                ? TimeSpan.FromMinutes(_debuggerTimeoutInMinutes)
                : _options.ExecutionTimeout;

            var requestTimeoutCts = new CancellationTokenSource(timeout);

            try
            {
                using (var combinedCts = CancellationTokenSource
                    .CreateLinkedTokenSource(requestTimeoutCts.Token,
                        context.RequestAborted))
                {
                    context.RequestAborted = combinedCts.Token;
                    await _next(context);
                }
            }
            catch (TaskCanceledException ex)
            {
                if (!requestTimeoutCts.IsCancellationRequested)
                {
                    throw;
                }

                context.Exception = ex;
                context.Result = QueryResult.CreateError(new QueryError(
                    "Execution timeout has been exceeded."));
                return;
            }
            finally
            {
                requestTimeoutCts.Dispose();
            }
        }
    }
}
