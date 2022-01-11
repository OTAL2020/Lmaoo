namespace Otal.lmaoo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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