using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        List<T> List();
        T GetId(int id);

    }
}
