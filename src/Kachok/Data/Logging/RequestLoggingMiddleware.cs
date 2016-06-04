using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Kachok.Data.Logging
{
    public class RequestLoggingMiddleware
    {
        private ILogger _logger;
        private RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next;                            
            this._logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items.Add("RequestID", System.Guid.NewGuid());
            _logger.LogInformation("Handling request: " + context.Request.Path);

            await _next.Invoke(context);

            _logger.LogInformation("Finished handling request.");

            IRequestLoggingRepository repository = context.RequestServices.GetService<IRequestLoggingRepository>();
            repository.SaveAll();
        }
    }
}
