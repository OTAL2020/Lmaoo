namespace Otal.lmaoo.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Otal.lmaoo.Service.Interfaces;

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
    }
}