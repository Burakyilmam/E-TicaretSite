using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        public List<User> ListCommentUser()
        {
            using (var c = new DataContext())
            {
                return c.Users.OrderBy(x => x.UserName).ToList();
            }
        }
        public bool CheckUserName(string UserName)
        {
            using (var c = new DataContext())
            {
                var value = c.Users.Any(a => a.UserName == UserName);
                return value;
            }
        }
    }
}
