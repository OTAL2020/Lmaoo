﻿using Microsoft.AspNetCore.Mvc;

namespace Otal.lmaoo.Web.Controllers
{
    public class ManagerController : BaseController
    {
        public ManagerController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
