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
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void Add(Address t)
        {
            _addressDal.Add(t);
        }

        public void Delete(Address t)
        {
           _addressDal.Delete(t);
        }

        public Address Get(int id)
        {
           return _addressDal.GetId(id);
        }

        public List<Address> List()
        {
            return _addressDal.List();
        }

        public List<Address> ListUserAdress(int id)
        {
            return _addressDal.ListUserAdress(id);
        }

        public void Update(Address t)
        {
           _addressDal.Update(t);
        }
    }
}
