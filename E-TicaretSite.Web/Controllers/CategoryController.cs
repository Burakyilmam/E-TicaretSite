using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult CategoryList()
        {
            var value = cm.ListCategory();
            return View(value);
        }
    }
}
