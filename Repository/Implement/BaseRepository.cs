using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class BaseRepository<T>(FunewsManagementDbContext context) : IBaseRepository<T> where T : class
    {
        public FunewsManagementDbContext Context { get; } = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();
        
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IEnumerable<T> FindEnitiesByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        public T? FindEnityByConditionn(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
