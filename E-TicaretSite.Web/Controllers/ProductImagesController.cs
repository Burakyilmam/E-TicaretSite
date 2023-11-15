using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
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
                return RedirectToAction("GetProductImages", "Product", new { @id = productImage.ProductId });
            }
        }
        public IActionResult ProductImageDelete(int id)
        {
            var value = pim.Get(id);
            int productId = value.ProductId;
            pim.Delete(value);
            TempData["SuccessMessage"] = "Resim başarıyla silindi.";
            return RedirectToAction("GetProductImages", "Product", new { id = productId });
        }
        [HttpGet]
        public IActionResult EditProductImage(int id)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim);
                var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.UserName = username;
                    ViewBag.Id = userId;
                    ViewBag.UserName = User.Identity.Name;
                    var value = pim.Get(id);
                    return View(value);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult EditProductImage(ProductImage productImage)
        {
            pim.Update(productImage);
            return RedirectToAction("GetProductImages", "Product", new { @id = productImage.ProductId });
        }
    }
}

