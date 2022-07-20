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
    public class PortfolioManager : IPortfolioService
    {
        private IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void Add(Portfolio t)
        {
            _portfolioDal.Add(t);
        }

        public void Delete(Portfolio t)
        {
            _portfolioDal.Delete(t);
        }

        public Portfolio GetById(int id)
        {
            var getById = _portfolioDal.GetById(id);
            return getById;
        }

        public List<Portfolio> GetList()
        {
            var getList = _portfolioDal.GetList();
            return getList;
        }

        public void Update(Portfolio t)
        {
            _portfolioDal.Update(t);
        }
    }
}
