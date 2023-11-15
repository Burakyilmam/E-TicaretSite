using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Security.Claims;
using X.PagedList;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        DataContext c = new DataContext();
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult CategoryList(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().ToPagedList(page, 10);
                    return View(value);
                }
            }
            return View();     
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            bool isCategoryExist = cm.CheckCategoryName(category.Name);
            if (!isCategoryExist)
            {
                category.Statu = true;
                category.CreatedDate = DateTime.Now;
                cm.Add(category);
                return RedirectToAction("CategoryList", "Category");
            }
            else
            {
                TempData["ErrorMessage"] = "Kategori Adı Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Kategori Adı Yazınız.";
                return RedirectToAction("CategoryList");
            }

        }
        public IActionResult CategoryDelete(int id)
        {
            var value = cm.Get(id);
            cm.Delete(value);
            TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
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

                    MainCategoryManager mcm = new MainCategoryManager(new EfMainCategoryRepository());

                    var maincategories = mcm.List();

                    var maincategoryitems = maincategories.Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.MainCategoryName
                    }).ToList();

                    ViewBag.MainCategory = maincategoryitems;
                    var value = cm.Get(id);
                    return View(value);
                }
            }
            return View(); 
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            cm.Update(category);
            return RedirectToAction("CategoryList", "Category");
        }
        public IActionResult GetProduct(int id,string p,int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(pm.GetProduct(id).Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var products = pm.GetProduct(id).ToPagedList(page, 10);
                    return View(products);
                }
            }
            return View();
        }
        public IActionResult SortIdOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().OrderBy(x => x.Id).ToPagedList(page, 10);
                    return View(value);
                }
            }
            return View();

        }
        public IActionResult SortIdOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();

        }
        public IActionResult SortNameOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().OrderBy(x => x.Name).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortNameOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().OrderByDescending(x => x.Name).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortMainCategoryNameOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().OrderBy(x => x.MainCategory.MainCategoryName).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();          
        }
        public IActionResult SortMainCategoryNameOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().OrderByDescending(x => x.MainCategory.MainCategoryName).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();   
        }
        public IActionResult SortStatuOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortStatuOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.ListProductCategory().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = cm.ListProductCategory().OrderByDescending(x => x.Statu).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
    }
}
