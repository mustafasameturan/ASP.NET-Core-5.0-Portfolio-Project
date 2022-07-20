using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        private IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public void Add(Experience t)
        {
            _experienceDal.Add(t);
        }

        public void Delete(Experience t)
        {
            _experienceDal.Delete(t);
        }

        public Experience GetById(int id)
        {
            var getById = _experienceDal.GetById(id);
            return getById;
        }

        public List<Experience> GetList()
        {
            var getList = _experienceDal.GetList();
            return getList;
        }

        public void Update(Experience t)
        {
            _experienceDal.Update(t);
        }
    }
}
