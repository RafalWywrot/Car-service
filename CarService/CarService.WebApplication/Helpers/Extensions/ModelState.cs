using System.Collections.Generic;
using System.Web.Mvc;

namespace CarService.WebApplication.Helpers.Extensions
{
    public static class ModelState
    {
        public static void AddError(this ModelStateDictionary modelState, string error)
        {
            modelState.AddModelError("", error);
        }

        public static void AddErrors(this ModelStateDictionary modelState, IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                modelState.AddModelError("", error);
            }
        }
    }
}