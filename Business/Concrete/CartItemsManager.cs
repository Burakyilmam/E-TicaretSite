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
    public class CartItemsManager : ICartItemsService
    {
        ICartItemsDal _cartItemsDal;

        public CartItemsManager(ICartItemsDal cartItemsDal)
        {
            _cartItemsDal = cartItemsDal;
        }

        public void Add(CartItems t)
        {
            _cartItemsDal.Add(t);
        }

        public void Delete(CartItems t)
        {
            throw new NotImplementedException();
        }

        public CartItems Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CartItems> List()
        {
            return _cartItemsDal.List();
        }

        public List<CartItems> ListCartItemsWith(int id)
        {
            return _cartItemsDal.ListCartItemsWith(id);
        }

        public void Update(CartItems t)
        {
            throw new NotImplementedException();
        }
    }
}
