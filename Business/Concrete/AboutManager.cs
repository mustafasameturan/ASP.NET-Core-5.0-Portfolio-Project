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
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About t)
        {
            _aboutDal.Add(t);
        }

        public void Delete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About GetById(int id)
        {
            var getById = _aboutDal.GetById(id);
            return getById;
        }

        public List<About> GetList()
        {
            var getList = _aboutDal.GetList();
            return getList;
        }

        public void Update(About t)
        {
            _aboutDal.Update(t);
        }

    }
}
