using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Globalization;
using X.PagedList;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        [AllowAnonymous]
        public IActionResult HomePage(string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml",pm.ListMostViewProduct().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page,10));
            }
            return View();
        }
        [AllowAnonymous]
        public IActionResult Error(int code)
        {
            return View();
        }
    }
    }
