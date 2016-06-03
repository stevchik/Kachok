using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Kachok.Data.Logging
{
    public class DBLogger : ILogger
    {
        private IServiceProvider _serviceProvider;

        public DBLogger(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
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
                   
            var httpContext = _serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            if (httpContext != null && httpContext.RequestServices!= null)
            {
                ILoggingRepository repository = httpContext.RequestServices.GetService<ILoggingRepository>();
                repository.AddLog();
                repository.Dispose();
            }
        }
    }
}
