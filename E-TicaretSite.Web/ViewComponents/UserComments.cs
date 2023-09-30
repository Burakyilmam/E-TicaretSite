using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class UserComments : ViewComponent
    {
        DataContext c = new DataContext();
        public IViewComponentResult Invoke()
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.Username = User.Identity.Name;
            ViewBag.Id = user.Id;
            var comments = c.Comments.Where(x => x.UserId == user.Id && x.Statu == true).Count();
            ViewBag.comments = comments;
            return View();
        }
    }
}
