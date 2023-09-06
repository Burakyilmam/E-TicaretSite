using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        DataContext c = new DataContext();
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult UserComments(int id)
        {
            DataContext c = new DataContext();
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.Username = User.Identity.Name;
            ViewBag.Id = user.Id;
            var value = cm.ListUserComment(id);
            return View(value);
        }
        public IActionResult ProductComments(int id)
        {
            DataContext c = new DataContext();
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.Username = User.Identity.Name;
            ViewBag.Id = user.Id;
            var value = cm.ListProductComment(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult CommentAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CommentAdd(Comment c)
        {
            c.CreatedDate = DateTime.Today;
            c.Statu = true;
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim); 
                c.UserId = userId;
            }
            cm.Add(c);
            return RedirectToAction("ProductPage", "Product", new { @id = c.ProductId });
        }
        public IActionResult CommentList()
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
            var value = cm.ListCommentWith();
            return View(value);
        }
        public IActionResult AdminCommentAdd(Comment c)
        {
            c.CreatedDate = DateTime.Today;
            c.Statu = true;
            cm.Add(c);
            return RedirectToAction("CommentList","Comment");
        }
        public IActionResult CommentDelete(int id)
        {
            var value = cm.Get(id);
            cm.Delete(value);
            return RedirectToAction("CommentList", "Comment");
        }
    }
}
