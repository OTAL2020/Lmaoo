namespace Otal.lmaoo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseController : Controller
    {
        public IActionResult RedirectWithMessage(string message, string viewName, object model)
        {
            TempData["Message"] = message;
            return View(viewName, model);
        }

        public IActionResult RedirectWithError(string error, string viewName, object model)
        {
            TempData["Error"] = error;
            return View(viewName, model);
        }

        public IActionResult RedirectWithMessageAction(string message, string actionName, string controllerName, object routeValues)
        {
            TempData["Message"] = message;
            return RedirectToAction(actionName, controllerName, routeValues);
        }

        public IActionResult RedirectWithErrorAction(string error, string actionName, string controllerName, object routeValues)
        {
            TempData["Error"] = error;
            return RedirectToAction(actionName, controllerName, routeValues);
        }
    }
}
