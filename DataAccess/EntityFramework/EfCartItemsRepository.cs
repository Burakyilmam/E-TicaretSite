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
    public class EfCartItemsRepository : GenericRepository<CartItems>, ICartItemsDal
    {
        public List<CartItems> ListCartItemsWith(int id)
        {
            using (var c = new DataContext())
            {
                return c.CartItems.Include(x=>x.Product).Where(x => x.Statu == true && x.Cart.UserId == id && x.Cart.Statu == true).ToList();
            }
        }
        public List<CartItems> GetCartItemsByUserId(int userid,int cartid)
        {
            using (var c = new DataContext())
            {
                return c.CartItems.Include(x => x.Product).Where(x => x.Cart.UserId == userid && x.CartId == cartid).ToList();
            }
        }
    }
}
