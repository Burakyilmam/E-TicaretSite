using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListCommentProduct : ViewComponent
    {
        ProductManager pm = new ProductManager((new EfProductRepository()));
        public IViewComponentResult Invoke()
        {
            var value = pm.ListCommentProduct();
            return View(value);
        }
    }
}
