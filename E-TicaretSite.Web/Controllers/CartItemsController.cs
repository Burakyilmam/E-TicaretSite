using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.Controllers
{
    public class CartItemsController : Controller
    {
        DataContext c = new DataContext();
        CartItemsManager cm = new CartItemsManager(new EfCartItemsRepository());
        public IActionResult Index(int id)
        {
            var value = cm.ListCartItemsWith(id);
            return View(value);
        }
    }
}
