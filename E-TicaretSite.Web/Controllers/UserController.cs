using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        DataContext c = new DataContext();
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult UserPage(User u)
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
                    return View();
                }
            }
            return RedirectToAction("UserLogin", "User");
        }
        public IActionResult GetUserName(User u)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim);
                var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.Name = username;
                    ViewBag.Id = userId;
                    return View();

                }
            }
            return RedirectToAction("UserLogin", "User");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult UserRegister(User user)
        {
            bool isUserExists = um.CheckUserName(user.UserName);
            if (!isUserExists)
            {
                user.Statu = true;
                user.CreatedDate = DateTime.Now;
                user.Email = "";
                um.Add(user);
                return RedirectToAction("UserLogin", "User");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı Adı Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Kullanıcı Adı Yazınız.";
                return View();
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserLogin(User u)
        {

            var value = c.Users.FirstOrDefault(x => x.UserName == u.UserName && x.Password == u.Password && x.Statu);
            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,u.UserName),
                    new Claim(ClaimTypes.NameIdentifier, value.Id.ToString())
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal pr = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(pr);
                return RedirectToAction("UserPage", "User");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ProductUserLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ProductUserLogin(User u,int id)
        {

            var value = c.Users.FirstOrDefault(x => x.UserName == u.UserName && x.Password == u.Password && x.Statu);
            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,u.UserName),
                    new Claim(ClaimTypes.NameIdentifier, value.Id.ToString())
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal pr = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(pr);
                return RedirectToAction("ProductPage", "Product",new { id = id });
            }
            return View();
        }
        public async Task<IActionResult> UserLogout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("HomePage", "Home");
        }
        public IActionResult UserList()
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
            var value = um.List();
            return View(value);
        }
        public IActionResult UserDelete(int id)
        {
            var value = um.Get(id);
            um.Delete(value);   
            return RedirectToAction("UserList", "User");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var value = um.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            um.Update(user);
            return RedirectToAction("UserList", "User");
        }
    }
}
