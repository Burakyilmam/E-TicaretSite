﻿using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        DataContext c = new DataContext();
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult CategoryList()
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
            var value = cm.ListProductCategory();
            return View(value);
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
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var value = cm.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            cm.Update(category);
            return RedirectToAction("CategoryList", "Category");
        }
    }
}
