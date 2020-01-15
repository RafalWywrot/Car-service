using CarService.Logic.Services.Abstract;
using System.Web.Mvc;

namespace CarService.WebApplication.Helpers.ActionFilters
{
    public class BookingServiceStatusAfterVerifyFilter : ActionFilterAttribute
    {
    }

    public class BookingServiceStatusAfterVerifyActionFilter : IActionFilter
    {
        private readonly ICarMainteanceService carMainteanceService;

        public BookingServiceStatusAfterVerifyActionFilter(ICarMainteanceService carMainteanceService)
        {
            this.carMainteanceService = carMainteanceService;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var bookingServiceId = filterContext.ActionParameters["bookingServiceId"] as int?;
            if (bookingServiceId == null)
                return;

            var bookedService = carMainteanceService.GetBooking(bookingServiceId.Value);
            if (bookedService.DateStarted != null)
                return;

            filterContext.Result = new JsonResult
            {
                Data = new JsonObjectResponse("Ustal datę przed zaakceptowaniem" )
            };
            return;
        }
    }
}