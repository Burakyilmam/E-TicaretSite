using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Globalization;
using System.Security.Claims;
using X.PagedList;

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
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
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

                user.Profile = new Profile();
                user.Profile.Name = " ";
                user.Profile.Surname = " ";
                user.Profile.BirthDate = DateTime.Now;
                user.Profile.Email = " ";
                user.Profile.Gender = " ";
                user.Profile.PhoneNumber = " ";
                user.Profile.Statu = true;
                user.Profile.CreatedDate = DateTime.Now;

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
        public async Task<IActionResult> ProductUserLogin(User u, int id)
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
                return RedirectToAction("ProductPage", "Product", new { id = id });
            }
            return View();
        }
        public async Task<IActionResult> UserLogout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("HomePage", "Home");
        }
        public IActionResult UserList(string p, int page = 1)
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().ToPagedList(page, 10);
                    return View(value);
                }

            }
            return View();  
        }
        public IActionResult UserDelete(int id)
        {
            var value = um.Get(id);
            um.Delete(value);
            TempData["SuccessMessage"] = "Kullanıcı başarıyla silindi.";
            return RedirectToAction("UserList", "User");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
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
                    var value = um.Get(id);
                    return View(value);
                }
            }
            return View();

        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            um.Update(user);
            return RedirectToAction("UserList", "User");
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().OrderBy(x => x.Id).ToPagedList(page, 10);
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().OrderBy(x => x.UserName).ToPagedList(page, 10); ;
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().OrderByDescending(x => x.UserName).ToPagedList(page, 10); ;
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().OrderByDescending(x => x.Statu).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortDateOrderBy(string p, int page = 1)
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().OrderBy(x => x.CreatedDate).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortDateOrderByDescending(string p, int page = 1)
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
                        return View(um.List().Where(x => x.UserName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = um.List().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
    }
}
