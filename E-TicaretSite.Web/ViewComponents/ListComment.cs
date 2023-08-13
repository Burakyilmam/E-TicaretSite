using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListComment : ViewComponent
    {
        CommentManager cm = new CommentManager((new EfCommentRepository()));
        public IViewComponentResult Invoke(int id)
        {
            var value = cm.ListProductComment(id);
           return View(value);
        }
    }
}
