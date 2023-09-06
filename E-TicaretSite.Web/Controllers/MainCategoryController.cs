using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
        [Authorize]
        public class MainCategoryController : Controller
        {
            DataContext c = new DataContext();
            MainCategoryManager mcm = new MainCategoryManager(new EfMainCategoryRepository());
            public IActionResult MainCategoryList()
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
                    }
                }
                var value = mcm.List();
                return View(value);
            }
            [HttpGet]
            public IActionResult MainCategoryAdd()
            {
                return View();
            }
            [HttpPost]
            public IActionResult MainCategoryAdd(MainCategory mainCategory)
            {
                mainCategory.Statu = true;
                mainCategory.CreatedDate = DateTime.Now;
                mcm.Add(mainCategory);
                return RedirectToAction("MainCategoryList", "MainCategory");
            }
            public IActionResult CategoryDelete(int id)
            {
                var value = mcm.Get(id);
                mcm.Delete(value);
                return RedirectToAction("MainCategoryList", "MainCategory");
            }

            [HttpGet]
            public IActionResult EditCategory(int id)
            {
                var value = mcm.Get(id);
                return View(value);
            }
            [HttpPost]
            public IActionResult EditCategory(MainCategory mainCategory)
            {
                mcm.Update(mainCategory);
                return RedirectToAction("MainCategoryList", "MainCategory");
            }
        }
    }
