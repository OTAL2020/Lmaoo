namespace Otal.lmaoo.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Otal.lmaoo.Services.Interfaces;
    using Otal.lmaoo.Web.ViewModels.Admin;

    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService AdminService)
        {
            _adminService = AdminService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditUserActiveStatus(int Id, int Active)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var UserId = Id;
            _adminService.EditUserActiveStatus(UserId, Active);
            return View();
        }
    }
}