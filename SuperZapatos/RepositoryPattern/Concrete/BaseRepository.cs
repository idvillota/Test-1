using SuperZapatos.RepositoryPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SuperZapatos.RepositoryPattern.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T>
            where T : class
    {
        #region Campos

        internal DbSet<T> dbSet;
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Properties

        public IUnitOfWork UnitOfWork { get { return this.unitOfWork; } }

        internal DbContext Database { get { return this.unitOfWork.Db; } }

        #endregion

        #region Constructores
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            this.unitOfWork = unitOfWork;
            this.dbSet = this.unitOfWork.Db.Set<T>();
        }

        #endregion

        #region Metodos

        public int Delete(T entity)
        {
            if (this.unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dynamic obj = dbSet.Remove(entity);
            this.unitOfWork.Db.SaveChanges();
            return obj.ID;
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable().ToList();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> set = dbSet.AsQueryable();

            foreach (var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }
            return set;
        }

        public Dictionary<string, string> GetAuditNames(dynamic dynamicObject)
        {
            throw new NotImplementedException();
        }

        public virtual int Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            this.unitOfWork.Db.SaveChanges();
            return obj.ID;
        }

        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T Single(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            this.unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            this.unitOfWork.Db.SaveChanges();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter);
        }

        public IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            return dbSet.Include(children).Where(filter);
        }

        #endregion

    }
}