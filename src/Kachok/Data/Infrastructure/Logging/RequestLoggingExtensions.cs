using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Kachok.Data.Infrastructure.Logging
{
    public static class RequestLoggingExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder, ILoggerFactory loggerFactory)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>(loggerFactory);
        }
        
    }
}
