using Microsoft.AspNetCore.Mvc;

namespace Otal.lmaoo.Web.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
