using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListCartItems : ViewComponent
    {
        CartItemsManager cm = new CartItemsManager((new EfCartItemsRepository()));
        public IViewComponentResult Invoke()
        {
            DataContext c = new DataContext();
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            var value = cm.ListCartItemsWith(user.Id);
            return View(value);
        }
    }
}
