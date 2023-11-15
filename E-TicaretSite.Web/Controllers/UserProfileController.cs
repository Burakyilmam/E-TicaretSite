using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        DataContext c = new DataContext();
        ProfileManager pm = new ProfileManager(new EfProfileRepository());
        public IActionResult Profile(int id)
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
                    var value = pm.ListUserProfile(id);
                    return View(value);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = pm.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditProfile(Profile profile)
        {
            profile.Statu = true;
            pm.Update(profile);
            return RedirectToAction("Profile", "UserProfile", new { @id = profile.Id });
        }
    }
}
