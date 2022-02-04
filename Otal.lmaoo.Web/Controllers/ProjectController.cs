using Microsoft.AspNetCore.Mvc;

namespace Otal.lmaoo.Web.Controllers
{
    public class ProjectController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}