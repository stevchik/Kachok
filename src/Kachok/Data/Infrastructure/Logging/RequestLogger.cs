using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Kachok.Data.Infrastructure.Logging
{
    public class RequestLogger : ILogger
    {
        private IServiceProvider _serviceProvider;
        private string _categoryName = string.Empty;

        public RequestLogger(string categoryName, IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            this._categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            var httpContext = _serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            if (httpContext != null && httpContext.RequestServices != null)
            {
                IRequestLoggingRepository repository = httpContext.RequestServices.GetService<IRequestLoggingRepository>();

                var log = new RequestLog();

                log.Message = Trim(message, RequestLog.MaximumMessageLength);
                log.Date = DateTime.UtcNow;
                log.Level = logLevel.ToString();
                log.Logger = _categoryName;
                log.Thread = eventId.ToString();
                log.Browser = httpContext.Request.Headers["User-Agent"];
                log.Username = httpContext.User.Identity.Name;
                try { log.HostAddress = httpContext.Connection.LocalIpAddress?.ToString(); }
                catch (ObjectDisposedException) { log.HostAddress = "Disposed"; }
                log.Url = httpContext.Request.Path;
                if (exception != null)
                    log.Exception = Trim(exception.ToString(), RequestLog.MaximumExceptionLength);

                if (httpContext.Items.ContainsKey("RequestID"))
                {
                    log.RequestID = httpContext.Items["RequestID"].ToString();
                }
                repository.AddLog(log);
            }
           
        }

        private static string Trim(string value, int maximumLength)
        {
            return value.Length > maximumLength ? value.Substring(0, maximumLength) : value;
        }


    }
}
