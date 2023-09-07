using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListSimilarCategory : ViewComponent
    {
        ProductManager pm = new ProductManager((new EfProductRepository()));
        public IViewComponentResult Invoke(int id)
        {
            var similarcategory = pm.ListSimilarCategoryProduct(id);
            return View(similarcategory);
        }
    }
}
