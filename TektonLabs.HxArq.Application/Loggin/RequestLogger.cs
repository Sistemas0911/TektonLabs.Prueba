using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace TektonLabs.HxArq.Application.Loggin
{
    public class RequestLogger
    {
        private readonly RequestDelegate _next;

        public RequestLogger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            var logMessage = $"{context.Request.Method} {context.Request.Path} respondió en {stopwatch.ElapsedMilliseconds} ms";
            await File.AppendAllTextAsync("request_tektonlabs_log.txt", logMessage + "\n");
        }
    }
}
