using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICartItemsDal : IGenericDal<CartItems>
    {
        List<CartItems> ListCartItemsWith(int id);
        List<CartItems> GetCartItemsByUserId(int userid,int cartid);
    }
}
