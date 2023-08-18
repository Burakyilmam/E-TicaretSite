using Business.Abstract;
using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    public class CartController : Controller
    {
        DataContext c = new DataContext();
        CartManager cm = new CartManager(new EfCartRepository());
        public IActionResult MyCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                ViewBag.Username = User.Identity.Name;
                ViewBag.Id = user.Id;
                var cart = cm.GetCartByUserId(user.Id);
                return View(cart);
            }
            else
            {
                return RedirectToAction("UserLogin", "User");
            }
        }
    }
}
