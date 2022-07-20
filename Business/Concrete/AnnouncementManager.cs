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
    public class AnnouncementManager : IAnnouncementService
    {
        private IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void Add(Announcement t)
        {
            _announcementDal.Add(t);
        }

        public void Delete(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement GetById(int id)
        {
            var getById = _announcementDal.GetById(id);
            return getById;
        }

        public List<Announcement> GetList()
        {
            var getList = _announcementDal.GetList();
            return getList;
        }

        public void Update(Announcement t)
        {
            _announcementDal.Update(t);
        }
    }
}
