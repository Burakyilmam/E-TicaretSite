using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class UserCount : ViewComponent
    {
        DataContext c = new DataContext();
        public IViewComponentResult Invoke()
        {
            var user = c.Users.Where(x => x.Statu == true).Count();
            ViewBag.User = user;
            return View();
        }
    }
}
