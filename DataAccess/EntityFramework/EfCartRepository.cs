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
    public class EfCartRepository : GenericRepository<Cart>,ICartDal
    {
        public List<Cart> GetCartByUserId(int id)
        {
            using (var c = new DataContext())
            {
                return c.Carts.Include(x => x.CartItems).Where(x => x.UserId == id).ToList();
            }
        }
        public List<Cart> ListCartWith()
        {
            using (var c = new DataContext())
            {
                return c.Carts.Include(x=>x.User).Where(x => x.Statu == true).ToList();
            }
        }
    }
}
