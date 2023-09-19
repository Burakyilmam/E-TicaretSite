using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class CommentCount : ViewComponent
    {
        DataContext c = new DataContext();
        public IViewComponentResult Invoke()
        {
            var comment = c.Comments.Where(x => x.Statu == true).Count();
            ViewBag.Comment = comment;
            return View();
        }
    }
}
