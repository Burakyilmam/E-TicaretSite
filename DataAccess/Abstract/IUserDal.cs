using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        List<User> ListCommentUser();
        bool CheckUserName(string UserName);
    }
}
