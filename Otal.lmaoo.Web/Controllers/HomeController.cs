using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otal.lmaoo.Web.ViewModels;
using System.Diagnostics;

namespace Otal.lmaoo.Web.Controllers
{
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
