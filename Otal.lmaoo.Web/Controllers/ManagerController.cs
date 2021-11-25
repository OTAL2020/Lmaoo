using Microsoft.AspNetCore.Mvc;

namespace Otal.lmaoo.Web.Controllers
{
    public class ManagerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
