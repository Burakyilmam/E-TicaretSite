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

        public void Add(User t)
        {
            _userDal.Add(t);
        }

        public void Delete(User t)
        {
            _userDal.Delete(t);
        }

        public User Get(int id)
        {
            return _userDal.GetId(id);
        }

        public List<User> List()
        {
            return _userDal.List();
        }

        public void Update(User t)
        {
            _userDal.Update(t);
        }
        public List<User> ListCommentUser()
        {
            return _userDal.ListCommentUser();
        }

        public bool CheckUserName(string UserName)
        {
            return _userDal.CheckUserName(UserName);
        }
    }
}
