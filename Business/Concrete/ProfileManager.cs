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
    public class ProfileManager : IProfileService
    {
        IProfileDal _profileDal;
        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }

        public void Add(Profile t)
        {
            _profileDal.Add(t);
        }

        public void Delete(Profile t)
        {
            _profileDal.Delete(t);
        }

        public Profile Get(int id)
        {
            return _profileDal.GetId(id);
        }

        public List<Profile> List()
        {
            return _profileDal.List();
        }

        public List<Profile> ListUserProfile(int id)
        {
            return _profileDal.ListUserProfile(id);
        }

        public void Update(Profile t)
        {
            _profileDal.Update(t);
        }
    }
}
