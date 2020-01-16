using CarService.WebApplication.Models.ServiceBooking;
using System;
using System.Web.Mvc;

namespace CarService.WebApplication.Helpers.ActionFilters
{
    public class ServiceBookingDateTimeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var model = GetModel(filterContext);
            if (model == null)
                throw new NotImplementedException();

            if (model.AsSoonAsPossible == true)
                return;

            var modelState = filterContext.Controller.ViewData.ModelState;
            if (model.DateCreated == null)
            {
                modelState.AddModelError("DateCreated", "Uzupełnij datę");
                return;
            }

            var date = (DateTime)model.DateCreated;
            var dateTimeMin = DateTime.Now;
            if (date < dateTimeMin.Date)
            {
                modelState.AddModelError("DateCreated", "Nie można dodać usługi z historyczną datą");
                return;
            }

            return;
        }

        private ServiceBookingFormViewModel GetModel(ActionExecutingContext filterContext)
        {
            var modelParameter = filterContext.ActionParameters["model"];
            if (modelParameter == null)
                return null;
            
            return modelParameter as ServiceBookingFormViewModel;
        }
    }
}