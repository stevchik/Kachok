using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Data.Logging
{
    public static class RequestLoggingExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder, ILoggerFactory loggerFactory)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>(loggerFactory);
        }
        
    }
}
