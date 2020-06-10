using System;
using System.Collections.Immutable;

namespace HotChocolate.Execution.Utilities
{
    internal static class PreparedSelectionListExtensions
    {
        public static ResultMap EnqueueResolverTasks(
            this IPreparedSelectionList selections,
            IOperationContext operationContext,
            Func<NameString, Path> createPath,
            IImmutableDictionary<string, object?> scopedContext,
            object? parent)
        {
            int responseIndex = 0;
            ResultMap resultMap = operationContext.Result.RentResultMap(selections.Count);

            for (int i = 0; i < selections.Count; i++)
            {
                IPreparedSelection selection = selections[i];
                if (selection.IsVisible(operationContext.Variables))
                {
                    operationContext.Execution.Tasks.Register(
                        new ResolverTaskDefinition(
                            operationContext,
                            selection,
                            responseIndex++,
                            resultMap,
                            parent,
                            createPath(selection.ResponseName),
                            scopedContext));
                }
            }

            return resultMap;
        }
    }
}
