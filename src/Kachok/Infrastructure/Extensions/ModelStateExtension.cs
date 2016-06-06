using Kachok.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Infrastructure.Extensions
{
    public static class ModelStateExtension
    {
        public static IList<ViewModelError> GetViewModelErrors(this ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                return null;
            }

            var vmErrors = new List<ViewModelError>();
            foreach (var key in modelState.Keys)
            {
                var error = new ViewModelError();
                error.Field = key;
                error.Errors = modelState[key].Errors.Select(e => e.ErrorMessage).ToList();
                error.Exceptions = modelState[key].Errors.Where(e => e.Exception != null).Select(c => c.ToString())?.ToList();
                vmErrors.Add(error);
            }
            return vmErrors;
        }
    }
}
