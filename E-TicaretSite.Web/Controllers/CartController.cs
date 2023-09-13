using Business.Abstract;
using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
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
                ViewBag.UserName = User.Identity.Name;
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
            var existingCart = c.Carts.FirstOrDefault(cart => cart.UserId == user.Id && cart.Statu == true);
            int cartId;
            if (existingCart == null)
            {
                var newCart = new Cart()
                {
                    Statu = true,
                    CreatedDate = DateTime.Now,
                    UserId = user.Id,
                };
                cm.Add(newCart);
                c.SaveChanges();
                cartId = newCart.Id;
            }
            else
            {
                cartId = existingCart.Id;
            }

            var existingCartItem = c.CartItems.FirstOrDefault(item => item.ProductId == id && item.Cart.UserId == user.Id && item.Cart.Statu == true);

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
                    TotalPrice = 0,
                    Quantity = 1
                };
                cim.Add(newCartItem);
            }

            c.SaveChanges();
            return RedirectToAction("MyCart", "Cart");
        }
        public IActionResult CartList()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim);
                var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.UserName = username;
                    ViewBag.Id = userId;
                }
            }
            var cart = cm.ListCartWith();
            return View(cart);
        }
        public IActionResult GetCartItems(int cartid, int userid)
        {
            var cartItems = cim.GetCartItemsByUserId(userid, cartid);
            return View(cartItems);
        }
        public IActionResult Increase(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            var existingCartItem = c.CartItems.FirstOrDefault(item => item.ProductId == id && item.Cart.UserId == user.Id && item.Cart.Statu == true);
            var product = c.Products.FirstOrDefault(p => p.Id == id);

            if (product != null && existingCartItem.Quantity < product.Stock)
            {
                existingCartItem.Quantity += 1;
                c.SaveChanges();
            }
            c.SaveChanges();
            return RedirectToAction("MyCart", "Cart");
        }
        public IActionResult Decrease(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            var existingCartItem = c.CartItems.FirstOrDefault(item => item.ProductId == id && item.Cart.UserId == user.Id && item.Cart.Statu == true);

            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity > 0)
                {
                    existingCartItem.Quantity -= 1;
                }
            }
            c.SaveChanges();
            return RedirectToAction("MyCart", "Cart");
        }
        public IActionResult DeleteFromCart(int id)
        {
            var CartItem = c.CartItems.FirstOrDefault(p => p.ProductId == id);
            var value = cim.Get(CartItem.ProductId);
            cim.Delete(value);
            return RedirectToAction("MyCart", "Cart");
        }
        public IActionResult Clear(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            var existingCart = c.Carts.FirstOrDefault(cart => cart.UserId == user.Id && cart.Statu == true);
            id = existingCart.Id;
            var value = cm.Get(id);
            cm.Delete(value);
            return RedirectToAction("MyCart", "Cart");
        }
        public IActionResult CartCount()
        {
            //var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            //var cart = c.Carts.FirstOrDefault(cart => cart.UserId == user.Id && cart.Statu == true);
            //var count = c.CartItems.Where(x => x.Cart.UserId == user.Id && x.CartId == cart.Id).Sum(x=>x.Quantity);
            return View();
        }
    }
}


