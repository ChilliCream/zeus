using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using HotChocolate.Resolvers;
using Microsoft.Extensions.DiagnosticAdapter;

namespace HotChocolate.Execution.Instrumentation
{
    internal class ApolloTracingDiagnosticListener
    {
        private static readonly AsyncLocal<ApolloTracingResultBuilder>
            _builder = new AsyncLocal<ApolloTracingResultBuilder>();
        private const string _extensionKey = "tracing";
        private const string _startTimestampKey = "startTimestamp";

        private static ApolloTracingResultBuilder Builder
        {
            get
            {
                return _builder.Value ??
                    (_builder.Value = new ApolloTracingResultBuilder());
            }
        }

        [DiagnosticName(DiagnosticNames.Query)]
        public void QueryExecute() { /* enables query activity */ }

        [DiagnosticName(DiagnosticNames.StartQuery)]
        public void BeginQueryExecute()
        {
            Builder.SetRequestStartTime(
                Activity.Current.StartTimeUtc,
                Timestamp.GetNowInNanoseconds());
        }

        [DiagnosticName(DiagnosticNames.StopQuery)]
        public void EndQueryExecute(IExecutionResult result)
        {
            Builder.SetRequestDuration(Activity.Current.Duration);

            if (result is IQueryResult queryResult)
            {
                queryResult.Extensions.Add(_extensionKey, Builder.Build());
            }
        }

        [DiagnosticName(DiagnosticNames.Parsing)]
        public void QueryParsing() { /* enables parsing activity */ }

        [DiagnosticName(DiagnosticNames.StartParsing)]
        public void BeginQueryParsing()
        {
            SetStartTimestamp(Timestamp.GetNowInNanoseconds());
        }

        [DiagnosticName(DiagnosticNames.StopParsing)]
        public void EndQueryParsing()
        {
            long stopTimestamp = Timestamp.GetNowInNanoseconds();
            long startTimestamp = GetStartTimestamp();

            Builder.SetParsingResult(startTimestamp, stopTimestamp);
        }

        [DiagnosticName(DiagnosticNames.Validation)]
        public void QueryValidation() { /* enables validation activity */ }

        [DiagnosticName(DiagnosticNames.StartValidation)]
        public void BeginQueryValidation()
        {
            SetStartTimestamp(Timestamp.GetNowInNanoseconds());
        }

        [DiagnosticName(DiagnosticNames.StopValidation)]
        public void EndQueryValidation()
        {
            long stopTimestamp = Timestamp.GetNowInNanoseconds();
            long startTimestamp = GetStartTimestamp();

            Builder.SetValidationResult(startTimestamp, stopTimestamp);
        }

        [DiagnosticName(DiagnosticNames.Resolver)]
        public void ResolveFieldExecute() { /* enables resolver activity */ }

        [DiagnosticName(DiagnosticNames.StartResolver)]
        public void BeginResolveField()
        {
            SetStartTimestamp(Timestamp.GetNowInNanoseconds());
        }

        [DiagnosticName(DiagnosticNames.StopResolver)]
        public void EndResolveField(IResolverContext context)
        {
            long stopTimestamp = Timestamp.GetNowInNanoseconds();
            long startTimestamp = GetStartTimestamp();

            Builder.AddResolverResult(
                new ApolloTracingResolverRecord(context)
                {
                    StartTimestamp = startTimestamp,
                    EndTimestamp = stopTimestamp
                });
        }

        private static void SetStartTimestamp(long timestamp)
        {
            Activity.Current.AddTag(_startTimestampKey, timestamp.ToString());
        }

        private static long GetStartTimestamp()
        {
            return Convert.ToInt64(Activity.Current.Tags
                .First(t => t.Key == _startTimestampKey).Value);
        }
    }
}
