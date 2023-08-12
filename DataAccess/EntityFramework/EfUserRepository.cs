using DataAccess.Abstract;
using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfUserRepository : GenericRepository<User>,IUserDal
    {
    }
}
