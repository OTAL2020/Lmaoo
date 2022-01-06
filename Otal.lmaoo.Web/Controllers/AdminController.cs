using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otal.lmaoo.Services.Interfaces;
using Otal.lmaoo.Web.ViewModels;

namespace Otal.lmaoo.Web.Controllers
{
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
        public IActionResult getUserByIsActive(AdminViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


        }
    }
}
