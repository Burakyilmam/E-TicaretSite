using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult CommentList()
        {
            var value = cm.CommentList();
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
            c.UserId = 13;
            //var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //if (!string.IsNullOrEmpty(userIdClaim))
            //{
            //    int userId = int.Parse(userIdClaim);
            //    c.UserId = userId;
            //}
            cm.CommentAdd(c);
            return RedirectToAction("ProductPage", "Product", new { @id = c.ProductId });

        }
    }
}
