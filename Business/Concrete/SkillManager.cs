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
    public class SkillManager : ISkillService
    {
        private ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void Add(Skill t)
        {
            _skillDal.Add(t);
        }

        public void Delete(Skill t)
        {
            _skillDal.Delete(t);
        }

        public Skill GetById(int id)
        {
            var getById = _skillDal.GetById(id);
            return getById;
        }

        public List<Skill> GetList()
        {
            var getList = _skillDal.GetList();
            return getList;
        }

        public void Update(Skill t)
        {
            _skillDal.Update(t);
        }
    }
}
