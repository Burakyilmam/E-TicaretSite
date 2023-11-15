using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Security.Claims;
using X.PagedList;

namespace E_TicaretSite.Web.Controllers
{
    public class UserAddressController : Controller
    {

        DataContext c = new DataContext();
        AddressManager am = new AddressManager(new EfAddressRepository());
        public IActionResult Address(int id, string p, int page = 1)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(p))
            {
                if (!string.IsNullOrEmpty(userIdClaim))
                {
                    int userId = int.Parse(userIdClaim);
                    var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                    if (user != null)
                    {
                        var username = User.Identity.Name;
                        ViewBag.UserName = username;
                        ViewBag.Id = userId;
                        return View(am.ListUserAdress(id).Where(x => x.AddressText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                }
                return View();
            }
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim);
                var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.UserName = username;
                    ViewBag.Id = userId;
                    var value = am.ListUserAdress(id).ToPagedList(page, 10);
                    return View(value);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddressAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddressAdd(Address address)
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
                    address.Statu = true;
                    address.CreatedDate = DateTime.Now;
                    address.Country = "Türkiye";
                    address.UserId = userId;
                    am.Add(address);
                }
            }
            return RedirectToAction("Address", "UserAddress", new { @id = address.UserId });
        }

        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = am.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditAddress(Address address)
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
                    address.Statu = true;
                    address.Country = "Türkiye";
                    address.UserId = userId;
                    am.Update(address);
                }
            }
            return RedirectToAction("Address", "UserAddress", new { @id = address.UserId });
        }
        public IActionResult AddressDelete(Address address, int id)
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
                    var value = am.Get(id);
                    am.Delete(value);
                    TempData["SuccessMessage"] = "Adres başarıyla silindi.";
                    return RedirectToAction("Address", "UserAddress", new { @id = userId });
                }
            }
            return View();     
        }
    }
}

