using Business.Abstract;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void Add(Cart t)
        {
            _cartDal.Add(t);
        }

        public void Delete(Cart t)
        {
            throw new NotImplementedException();
        }

        public Cart Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetCartByUserId(int id)
        {
            return _cartDal.GetCartByUserId(id);
        }

        public List<Cart> List()
        {
           return _cartDal.List();
        }

        public void Update(Cart t)
        {
            throw new NotImplementedException();
        }
    }
}
