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
    public class ContactInformationManager : IContactInformationService
    {
        private IContactInformationDal _contactInformationDal;

        public ContactInformationManager(IContactInformationDal contactInformationDal)
        {
            _contactInformationDal = contactInformationDal;
        }

        public void Add(ContactInformation t)
        {
            _contactInformationDal.Add(t);
        }

        public void Delete(ContactInformation t)
        {
            _contactInformationDal.Delete(t);
        }

        public ContactInformation GetById(int id)
        {
            var getById = _contactInformationDal.GetById(id);
            return getById;
        }

        public List<ContactInformation>GetList()
        {
            var getList = _contactInformationDal.GetList();
            return getList;
        }

        public void Update(ContactInformation t)
        {
            _contactInformationDal.Update(t);
        }
    }
}
