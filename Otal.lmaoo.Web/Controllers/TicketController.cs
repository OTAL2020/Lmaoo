using Microsoft.AspNetCore.Mvc;

namespace Otal.lmaoo.Web.Controllers
{
    public class TicketController : BaseController
    {
        public TicketController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
