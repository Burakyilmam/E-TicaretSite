using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        List<User> ListCommentUser();
        bool CheckUserName(string UserName);
    }
}
