using CarService.Logic.Services.Abstract;
using System;
using System.Web.Mvc;
namespace CarService.WebApplication.Helpers.ActionFilters
{
    public class BookingServiceMechanicAssignedFilter : ActionFilterAttribute
    {
    }
    public class BookingServiceMechanicAssignedActionFilter : IActionFilter
    {
        private readonly ICarMainteanceService carMainteanceService;

        public BookingServiceMechanicAssignedActionFilter(ICarMainteanceService carMainteanceService)
        {
            this.carMainteanceService = carMainteanceService;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user.IsInRole(SystemRoles.Admin))
                return;

            if (!filterContext.ActionParameters.ContainsKey("bookingServiceId"))
                throw new NotImplementedException();

            
            int bookingServiceId = Convert.ToInt32(filterContext.ActionParameters["bookingServiceId"]);
            var bookedService = carMainteanceService.GetBooking(bookingServiceId);
            if (!string.IsNullOrEmpty(bookedService.MechanicId))
                return;

            filterContext.Result = new JsonResult
            {
                Data = new JsonObjectResponse("Nie można zmieniać statusów bez przypisanego mechanika")
            };
        }
    }
}