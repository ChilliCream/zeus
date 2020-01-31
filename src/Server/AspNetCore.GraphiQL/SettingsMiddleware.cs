﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace HotChocolate.AspNetCore.GraphiQL
{
    internal sealed class SettingsMiddleware
    {
        private readonly GraphiQLOptions _options;
        private readonly string _queryPath;
        private readonly string _subscriptionPath;

        public SettingsMiddleware(
            RequestDelegate next,
            GraphiQLOptions options)
        {
            Next = next;
            _options = options
                ?? throw new ArgumentNullException(nameof(options));

            Uri uiPath = UriFromPath(options.Path);
            Uri queryPath = UriFromPath(options.QueryPath);
            Uri subscriptionPath = UriFromPath(options.SubscriptionPath);

            _queryPath = uiPath.MakeRelativeUri(queryPath).ToString();
            _subscriptionPath = uiPath.MakeRelativeUri(subscriptionPath)
                .ToString();
        }

        internal RequestDelegate Next { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            string queryUrl = BuildUrl(context.Request, false, _queryPath);
            string subscriptionUrl = BuildUrl(context.Request, true,
                _subscriptionPath);
            string enableSubscriptions = _options.EnableSubscription
                ? "true" : "false";

            context.Response.ContentType = "application/javascript";
            await context.Response.WriteAsync($@"
                window.Settings = {{
                    url: ""{queryUrl}"",
                    subscriptionUrl: ""{subscriptionUrl}"",
                    enableSubscriptions: {enableSubscriptions}
                }}
            ",
            context.GetCancellationToken())
            .ConfigureAwait(false);
        }

        private static string BuildUrl(
            HttpRequest request,
            bool websocket,
            string path)
        {
            string uiPath = request.PathBase.Value
                .Substring(0, request.PathBase.Value.Length - 11);
            string scheme = request.Scheme;

            if (websocket)
            {
                scheme = request.IsHttps() ? "wss" : "ws";
            }

            return UriHelper.BuildAbsolute(
                scheme, request.Host, uiPath + path)
                .TrimEnd('/');
        }

        private static Uri UriFromPath(PathString path)
        {
            return new Uri(
                "http://p" +
                (path.HasValue ? path.Value : "/").TrimEnd('/') +
                "/");
        }
    }
}
