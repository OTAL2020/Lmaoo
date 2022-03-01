using Microsoft.AspNetCore.Mvc;

namespace Otal.lmaoo.Web.Controllers
{
    public class FeatureController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}