using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ProductCommentCount : ViewComponent
    {
        DataContext c = new DataContext();
        public IViewComponentResult Invoke(int id)
        {
            var comment = c.Comments.Where(x => x.Statu == true && x.Product.Id == id).Count();
            ViewBag.ProductCommentCount = comment;
            return View();
        }
    }
}
