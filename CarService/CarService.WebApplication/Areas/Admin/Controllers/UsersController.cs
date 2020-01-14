using AutoMapper;
using CarService.WebApplication.Controllers;
using CarService.WebApplication.Helpers;
using CarService.WebApplication.Models.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using CarService.Identity;
using System.Web.Security;
using CarService.WebApplication.Helpers.Extensions;

namespace CarService.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = SystemRoles.Admin)]
    public class UsersController : BaseController
    {
        private ApplicationUserManager _userManager;

        public UsersController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(Mapper.Map<IEnumerable<UserBasicViewModel>>(users.Where(x => x.Active)));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(UserBasicViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                Active = true
            };

            var password = Membership.GeneratePassword(10, 2);
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                ModelState.AddErrors(result.Errors);
                return View(model);
            }

            var addedToRoleResult = await _userManager.AddToRoleAsync(user.Id, SystemRoles.Mechanic);
            if (!addedToRoleResult.Succeeded)
            {
                ModelState.AddErrors(addedToRoleResult.Errors);
                return View(model);
            }

            var callbackUrl = Url.Action("Login", "Account", new { @area = "" }, protocol: Request.Url.Scheme);
            await _userManager.SendEmailAsync(model.Email, "Your account has been created", string.Format(Resource.EmailMechanicCreatedAccountContent, model.Name, model.Email, password, callbackUrl));

            return RedirectToAction("Index", "Users", new { @area = "Admin" });
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new NullReferenceException();

            return View(Mapper.Map<UserBasicViewModel>(user));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserBasicViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                throw new NullReferenceException();

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            await _userManager.UpdateAsync(user);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new NullReferenceException();

            user.Active = false;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}