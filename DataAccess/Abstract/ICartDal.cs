using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICartDal : IGenericDal<Cart>
    {
        List<Cart> GetCartByUserId(int id);
        List<Cart> ListCartWith();
    }
}
