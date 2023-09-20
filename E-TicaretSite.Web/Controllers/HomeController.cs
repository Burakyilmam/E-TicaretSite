using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        [AllowAnonymous]
        public IActionResult HomePage(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml",pm.ListMostViewProduct().Where(x => x.Name.ToLower().Contains(p.ToLower())));
            }
            return View();
        }
    }
}
