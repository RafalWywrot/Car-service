using CarService.WebApplication.Helpers;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("IndexUnathorize");

            if (User.IsInRole(SystemRoles.User))
                return View("IndexRoleUser");

            return RedirectToAction("Index", "Book", new { @area = "Admin" });
        }

        public ViewResult Contact()
        {
            return View();
        }
    }
}