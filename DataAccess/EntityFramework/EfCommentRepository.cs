using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> ListProductComment(int id)
        {
            using (var c = new DataContext())
            {
                return c.Comments.Include(x => x.User).Include(x => x.Product).Where(x => (x.Statu == true) && (x.ProductId == id)).ToList();
            }
        }
        public List<Comment> ListUserComment(int id)
        {
            using (var c = new DataContext())
            {
                return c.Comments.Include(x => x.User).Include(x => x.Product).Where(x => (x.Statu == true) && (x.UserId == id)).ToList();
            }
        }
        public List<Comment> ListCommentWith()
        {
            using (var c = new DataContext())
            {
                return c.Comments.Include(x => x.User).Include(x => x.Product).ToList();
            }
        }
    }
}
