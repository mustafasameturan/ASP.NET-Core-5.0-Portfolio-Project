using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenericRepository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T t)
        {
            using var _c = new Context();
            _c.Add(t);
            _c.SaveChanges();
        }

        public void Delete(T t)
        {
            using (Context context = new Context())
            {
                var deletedEntity = context.Entry(t);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var _c = new Context();
            return _c.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            using var _c = new Context();
            return _c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var _c = new Context();
            return _c.Set<T>().ToList();    
        }

        public void Update(T t)
        {
            using var _c = new Context();
            _c.Update(t);
            _c.SaveChanges();
        }
    }
}
