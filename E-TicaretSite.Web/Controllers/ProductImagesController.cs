using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.Controllers
{
    public class ProductImagesController : Controller
    {
        DataContext c = new DataContext();
        ProductImageManager pim = new ProductImageManager(new EfProductImageRepository());
        [HttpGet]
        public IActionResult ProductImageAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductImageAdd(ProductImage productImage)
        {
            productImage.Statu = true;
            productImage.CreatedDate = DateTime.Now;
            pim.Add(productImage);
            return RedirectToAction("GetProductImages", "Product", new { @id = productImage.ProductId });
        }
    }
}

