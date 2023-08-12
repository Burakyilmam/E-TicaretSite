using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
