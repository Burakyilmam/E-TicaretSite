using Business.Abstract;
using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using X.PagedList;

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
        public IActionResult CartList(string p,int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListCartWith().Where(x => x.User.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var cart = cm.ListCartWith().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
                    return View(cart);
                }
            }
            return View();
        }
        public IActionResult GetCartItems(int cartid, int userid)
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
                    var cartItems = cim.GetCartItemsByUserId(userid, cartid);
                    return View(cartItems);
                }
            }
            return View();
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
                if (existingCartItem.Quantity == 0)
                {
                    cim.Delete(existingCartItem);
                    return RedirectToAction("MyCart", "Cart");
                }
            }
            c.SaveChanges();
            return RedirectToAction("MyCart", "Cart");
        }
        public IActionResult DeleteFromCart(int id)
        {
            var cartItem = c.CartItems.FirstOrDefault(p => p.ProductId == id);
            if (cartItem != null)
            {
                cim.Delete(cartItem);
                return RedirectToAction("MyCart", "Cart");
            }
            return View();
        }

        public IActionResult Clear(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            var existingCart = c.Carts.FirstOrDefault(cart => cart.UserId == user.Id && cart.Statu == true);
            id = existingCart.Id;
            var value = cm.Get(id);
            cm.Delete(value);
            TempData["SuccessMessage"] = "Sepet başarıyla temizlendi.";
            return RedirectToAction("MyCart", "Cart");
        }

        public IActionResult SortIdOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListCartWith().Where(x => x.User.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListCartWith().OrderBy(x => x.Id).ToPagedList(page, 10);
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortIdOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListCartWith().Where(x => x.User.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListCartWith().OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();

        }
        public IActionResult SortNameOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListCartWith().Where(x => x.User.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListCartWith().OrderBy(x => x.User.UserName).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortNameOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListCartWith().Where(x => x.User.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListCartWith().OrderByDescending(x => x.User.UserName).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortStatuOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListCartWith().Where(x => x.User.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListCartWith().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortStatuOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListCartWith().Where(x => x.User.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListCartWith().OrderByDescending(x => x.Statu).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
    }
}


