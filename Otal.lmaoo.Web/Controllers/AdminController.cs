﻿namespace Otal.lmaoo.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Otal.lmaoo.Services.Interfaces;
    using Otal.lmaoo.Web.ViewModels;

    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService AdminService)
        {
            _adminService = AdminService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(string returnUrl = "/admin/")
        {
            var vm = new AdminViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult IsActiveSelect(AdminViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var active = vm.IsActiveSelect;

            if (active == "true")
            {
                _adminService.GetByActive(1);
            }
            else
            {
                _adminService.GetByActive(0);
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult DeactivateUser(AdminViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = vm.UserId;
            _adminService.DeactivateUser(user);
            return View(vm);
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