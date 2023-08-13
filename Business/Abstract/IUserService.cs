using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void UserAdd(User user);
        void UserDelete(User user);
        void UserUpdate(User user);
        User GetUser(int id);
        List<User> ListUser();
    }
}
