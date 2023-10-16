using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListProductAttributeAll : ViewComponent
    {
        ProductAttributeManager pam = new ProductAttributeManager((new EfProductAttributeRepository()));
        public IViewComponentResult Invoke(int id)
        {
            var value = pam.ListProductAttributeWithCategory(id);
            return View(value);
        }
    }
}
