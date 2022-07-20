using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void Add(SocialMedia t)
        {
            _socialMediaDal.Add(t);
        }

        public void Delete(SocialMedia t)
        {
            _socialMediaDal.Delete(t);
        }

        public SocialMedia GetById(int id)
        {
            var getById = _socialMediaDal.GetById(id);
            return getById;
        }

        public List<SocialMedia> GetList()
        {
            var getList = _socialMediaDal.GetList();
            return getList;
        }

        public void Update(SocialMedia t)
        {
            _socialMediaDal.Update(t);
        }
    }
}
