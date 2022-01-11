namespace Otal.lmaoo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Otal.lmaoo.Web.ViewModels;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}