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
            _cartItemsDal.Delete(t);
        }

        public CartItems Get(int id)
        {
            return _cartItemsDal.GetId(id);
        }

        public List<CartItems> GetCartItemsByUserId(int userid, int cartid)
        {
            return _cartItemsDal.GetCartItemsByUserId(userid, cartid);
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
            _cartItemsDal.Update(t);
        }
    }
}
