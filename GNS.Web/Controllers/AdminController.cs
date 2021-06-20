using Microsoft.AspNetCore.Mvc;

namespace GNS.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
