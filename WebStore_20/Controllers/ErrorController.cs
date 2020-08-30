using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
