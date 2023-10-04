using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using X.PagedList;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        DataContext c = new DataContext();
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult UserComments(int id, string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListUserComment(id).Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = cm.ListUserComment(id).ToPagedList(page,10);
            return View(value);
        }
        public IActionResult ProductComments(int id, string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListProductComment(id).Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = cm.ListProductComment(id).ToPagedList(page, 10);
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
        public IActionResult CommentList(string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var userName = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = cm.ListCommentWith().ToPagedList(page,10);
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
        [HttpGet]
        public IActionResult EditComment(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            UserManager um = new UserManager(new EfUserRepository());
            ProductManager pm = new ProductManager(new EfProductRepository());

            var users = um.List();

            var useritems = users.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.UserName
            }).ToList();

            var products = pm.List();

            var productitems = products.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            ViewBag.Product = productitems;
            ViewBag.User = useritems;
            var value = cm.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditComment(Comment comment)
        {
            cm.Update(comment);
            return RedirectToAction("CommentList", "Comment");
        }
        public IActionResult SortIdOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderBy(x => x.Id).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult SortIdOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortNameOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderBy(x => x.User.UserName).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortNameOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderByDescending(x => x.User.UserName).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult SortTextOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderBy(x => x.CommentText).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortTextOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderByDescending(x => x.CommentText).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortProductOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderBy(x => x.Product.Name).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortProductOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderByDescending(x => x.Product.Name).ToPagedList(page, 10); ;
            return View(value);
        }

        public IActionResult SortDateOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderBy(x => x.CreatedDate).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortDateOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10); ;
            return View(value);
        }
      
        public IActionResult SortStatuOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortStatuOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.ListCommentWith().Where(x => x.CommentText.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = cm.ListCommentWith().OrderByDescending(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }
    }
}
