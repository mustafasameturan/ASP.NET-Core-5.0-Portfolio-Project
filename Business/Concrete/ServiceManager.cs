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
    public class ServiceManager : IServiceService
    {
        private IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Add(Service t)
        {
            _serviceDal.Add(t);
        }

        public void Delete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public Service GetById(int id)
        {
            var getById = _serviceDal.GetById(id);
            return getById;
        }

        public List<Service> GetList()
        {
            var getList = _serviceDal.GetList();
            return getList;
        }

        public void Update(Service t)
        {
            _serviceDal.Update(t);
        }
    }
}
