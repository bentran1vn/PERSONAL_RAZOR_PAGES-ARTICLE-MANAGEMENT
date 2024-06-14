using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindEnitiesByCondition(Expression<Func<T, bool>> expression);
        T? FindEnityByConditionn(Expression<Func<T, bool>> expression);
    }
}
