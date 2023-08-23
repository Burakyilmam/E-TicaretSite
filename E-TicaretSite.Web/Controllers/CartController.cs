using Business.Abstract;
using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    public class CartController : Controller
    {
        DataContext c = new DataContext();
        CartManager cm = new CartManager(new EfCartRepository());
        CartItemsManager cim = new CartItemsManager(new EfCartItemsRepository());
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
        [HttpGet]
        public IActionResult AddToCart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            
            var newCart = new Cart()
            {
                Statu = true,
                CreatedDate = DateTime.Now,
                UserId = user.Id,
            };
            cm.Add(newCart);
            c.SaveChanges();
            int cartId = newCart.Id;

            var existingCartItem = c.CartItems.FirstOrDefault(item => item.ProductId == id && item.Cart.UserId == user.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
            }
            else
            {
                var newCartItem = new CartItems
                {
                    Statu = true,
                    CreatedDate = DateTime.Now,
                    CartId = cartId,
                    ProductId = id,
                    TotalPrice =0,
                    Quantity = 1
                };
                cim.Add(newCartItem);
            }

            c.SaveChanges();
            return RedirectToAction("MyCart", "Cart");
        }
    }
}


