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
    public class MainPageManager : IMainPageService
    {
        private IMainPageDal _mainPageDal;

        public MainPageManager(IMainPageDal mainPageDal)
        {
            _mainPageDal = mainPageDal;
        }

        public void Add(MainPage t)
        {
            _mainPageDal.Add(t);
        }

        public void Delete(MainPage t)
        {
            _mainPageDal.Delete(t);
        }

        public MainPage GetById(int id)
        {
            var getById = _mainPageDal.GetById(id);
            return getById;
        }

        public List<MainPage> GetList()
        {
            var getList = _mainPageDal.GetList();
            return getList;
        }

        public void Update(MainPage t)
        {
            _mainPageDal.Update(t);
        }
    }
}
