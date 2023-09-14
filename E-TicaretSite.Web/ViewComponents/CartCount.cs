using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_TicaretSite.Web.ViewComponents
{
    public class CartCount : ViewComponent
    {
        DataContext c = new DataContext();
        CartManager cm = new CartManager(new EfCartRepository());
        CartItemsManager cim = new CartItemsManager(new EfCartItemsRepository());
        public IViewComponentResult Invoke()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(0); // Kullanıcı giriş yapmamışsa sepet sayısını 0 olarak görüntüle
            }
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (user == null)
            {
                return View(0);
            }
            var cart = c.Carts.FirstOrDefault(cart => cart.UserId == user.Id && cart.Statu == true);

            int totalQuantity = 0;

            if (cart != null)
            {
                totalQuantity = c.CartItems
                    .Where(item => item.CartId == cart.Id && item.Cart.UserId == user.Id && item.Cart.Statu == true)
                    .Sum(item => item.Quantity);
            }
            ViewBag.Quantity = totalQuantity;

            return View();
        }
    }
}
