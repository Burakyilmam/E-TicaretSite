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
                return c.Comments.Where(x => (x.Statu == true) && (x.ProductId == id)).ToList();
            }

        }
    }
}
