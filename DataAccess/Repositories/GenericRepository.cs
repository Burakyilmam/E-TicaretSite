using DataAccess.Abstract;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        DataContext c = new DataContext();
        public void Add(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }

        public void Delete(T t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetId(int id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> List()
        {
            return c.Set<T>().ToList();
        }
        public void Update(T t)
        {
            c.Update(t);
            c.SaveChanges();
        }
    }
}
