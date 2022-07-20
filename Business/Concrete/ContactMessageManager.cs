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
    public class ContactMessageManager : IContactMessageService
    {
        private IContactMessageDal _contactMessageDal;

        public ContactMessageManager(IContactMessageDal contactMessageDal)
        {
            _contactMessageDal = contactMessageDal;
        }

        public void Add(ContactMessage t)
        {
            _contactMessageDal.Add(t);
        }

        public void Delete(ContactMessage t)
        {
            _contactMessageDal.Delete(t);
        }

        public ContactMessage GetById(int id)
        {
            var getById = _contactMessageDal.GetById(id);
            return getById;
        }

        public List<ContactMessage> GetList()
        {
            var getList = _contactMessageDal.GetList();
            return getList;
        }

        public void Update(ContactMessage t)
        {
            _contactMessageDal.Update(t);
        }
    }
}
