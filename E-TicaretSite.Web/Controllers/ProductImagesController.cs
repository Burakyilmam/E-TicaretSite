using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

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
            bool isProductImageExist = pim.CheckProductImageUrl(productImage.ImageUrl);
            if (!isProductImageExist)
            {
                productImage.Statu = true;
                productImage.CreatedDate = DateTime.Now;
                pim.Add(productImage);
                return RedirectToAction("GetProductImages", "Product", new { @id = productImage.ProductId });
            }
            else
            {
                TempData["ErrorMessage"] = "Resim Url Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Resim Url Yazınız.";
                return RedirectToAction("GetProductImages","Product", new { @id = productImage.ProductId });
            }
        }
    }
}

