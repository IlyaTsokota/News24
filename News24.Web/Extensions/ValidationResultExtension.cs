using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ModelStateDictionary = System.Web.Mvc.ModelStateDictionary;

namespace News24.Web.Extensions
{
    public static class ValidationResultExtension
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<ValidationResult> validationResults, string defaultErrorKey = null)
        {
            if (validationResults == null)
            {
                return;
            }

            foreach (var validationResult in validationResults)
            {
                var key = validationResult.MemberNames.FirstOrDefault() ?? defaultErrorKey ?? string.Empty;
                modelState.AddModelError(key, validationResult.ErrorMessage);
            }
        }
    }
}