using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAddressDal : IGenericDal<Address>
    {
        List<Address> ListUserAdress(int id);
    }
}
