namespace Otal.lmaoo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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