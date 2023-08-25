using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListCommentUser : ViewComponent
    {
        UserManager um = new UserManager((new EfUserRepository()));
        public IViewComponentResult Invoke()
        {
            var value = um.ListCommentUser();
            return View(value);
        }
    }
}
