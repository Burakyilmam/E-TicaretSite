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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> ListUser()
        {
            throw new NotImplementedException();
        }

        public void UserAdd(User user)
        {
            _userDal.Add(user);
        }

        public void UserDelete(User user)
        {
            throw new NotImplementedException();
        }

        public void UserUpdate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
