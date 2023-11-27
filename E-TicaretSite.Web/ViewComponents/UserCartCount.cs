using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_TicaretSite.Web.ViewComponents
{
    public class UserCartCount : ViewComponent
    {
        DataContext c = new DataContext();
        public IViewComponentResult Invoke()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(0);
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
