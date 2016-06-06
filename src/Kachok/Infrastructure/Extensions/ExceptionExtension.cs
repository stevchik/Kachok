﻿using Kachok.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Kachok.Infrastructure.Extensions
{
    public static class ExceptionExtension
    {
        public static IList<ViewModelError> GetViewModelErrors(this Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            var vmErrors = new List<ViewModelError>();

            var error = new ViewModelError();
            error.Field = string.Empty;
            error.Errors = new List<string>();
            error.Exceptions = new List<string>() { ex.ToString() };
            vmErrors.Add(error);

            return vmErrors;
        }

        public static void LogException(this Exception ex, ILogger logger, string message)
        {
            logger.LogCritical(0, ex, message);
        }
    }
}
