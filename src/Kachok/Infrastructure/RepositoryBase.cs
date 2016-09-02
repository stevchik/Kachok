using Kachok.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Kachok.Infrastructure
{
    public abstract class RepositoryBase<T, DContext> 
        where T : class, IHaveId 
        where DContext : DbContext
    {
        #region Properties
        private DContext _dataContext;
        private readonly DbSet<T> _dbSet;

       
        protected DContext DbContext
        {
            get { return _dataContext; }
        }
        #endregion

        protected RepositoryBase(DContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Where(c => c.Id == id).FirstOrDefault<T>();
        }

        public bool SaveAll()
        {
            return _dataContext.SaveChanges() > 0;
        }
        #endregion

    }

}
