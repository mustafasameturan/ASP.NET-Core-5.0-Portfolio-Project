using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetList();
        List<T> GetByFilter(Expression<Func<T,bool>>filter);
    }
}
