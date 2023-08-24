using DataAccess.Context;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService : IGenericService<Cart>
    {
        List<Cart> GetCartByUserId(int id);
        List<Cart> ListCartWith();
    }
}
