using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Entities;
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
            user.Statu = true;
            user.CreatedDate = DateTime.Now;
            user.Email = "";
            um.UserAdd(user);
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
