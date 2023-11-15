﻿using DataAccess.Abstract;
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
    public class EfProfileRepository : GenericRepository<Profile>, IProfileDal
    {
        public List<Profile> ListUserProfile(int id)
        {
            using (var c = new DataContext())
            {
                return c.Profiles.Include(x => x.User).Where(x => (x.Statu == true) && (x.User.Id == id)).ToList();
            }
        }
    }
}
