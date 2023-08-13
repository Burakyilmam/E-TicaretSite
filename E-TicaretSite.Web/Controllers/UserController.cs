using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult UserPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserRegister(User user)
        {
            UserValidator uv = new UserValidator();
            ValidationResult result = uv.Validate(user);
            if (result.IsValid)
            {
                user.Statu = true;
                user.CreatedDate = DateTime.Now;
                user.Email = "";
                um.UserAdd(user);
                return View();
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult UserLogin()
        {
            return View();
        }
        public IActionResult UserLogout()
        {
            return View();
        }
    }
}
