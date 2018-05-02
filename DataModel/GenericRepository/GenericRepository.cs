using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataModel.GenericRepository
{
    /// <summary>
    /// Generic repository for CRUD/Entity operations
    /// </summary>
    public class GenericRepository<TEntity> where TEntity:class
    {
        internal BlogTechnicallyEntities context;
        internal DbSet<TEntity> DbSet;


        /// <summary>
        /// Constructor to initialize dbContext and dbSet
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository (BlogTechnicallyEntities context)
        {
            this.context = context;
            this.DbSet = context.Set<TEntity>();
        }


        /// <summary>
        /// Generic Get Method
        /// </summary>
        /// <returns>returns a list of objects of type TEntity</returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }
        
        
        /// <summary>
        /// Generic Get Method returns data based on an Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }


        /// <summary>
        /// Inserts an entity into Db
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }


        /// <summary>
        /// Generic Delete Method to delete an entity
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Generic Update Method to update an entity
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        /// <summary>  
        /// generic method to get many record on the basis of a condition.  
        /// </summary>  
        /// <param name="where"></param>  
        /// <returns></returns> 
        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).ToList();
        }

        // <summary>  
        /// generic method to get many record on the basis of a condition but query able.  
        /// </summary>  
        /// <param name="where"></param>  
        /// <returns></returns>  
        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity,bool> where)
        {
            return DbSet.Where(where).AsQueryable();
        }

        /// <summary>  
        /// generic get method , fetches data for the entities on the basis of condition.  
        /// </summary>  
        /// <param name="where"></param>  
        /// <returns></returns>  
        public TEntity Get(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).FirstOrDefault();
        }

        /// <summary>  
        /// generic delete method , deletes data for the entities on the basis of condition.  
        /// </summary>  
        /// <param name="where"></param>  
        /// <returns></returns>  
        public void Delete(Func<TEntity,bool>where)
        {
            IQueryable<TEntity> objects = DbSet.Where<TEntity>(where).AsQueryable();
            foreach (var entity in objects)
            {
                DbSet.Remove(entity);
            }
        }


        /// <summary>  
        /// generic method to fetch all the records from db  
        /// </summary>  
        /// <returns></returns> 
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        /// <summary>  
        /// Inclue multiple  
        /// </summary>  
        /// <param name="predicate"></param>  
        /// <param name="include"></param>  
        /// <returns></returns>  
        public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        /// <summary>  
        /// Generic method to check if entity exists  
        /// </summary>  
        /// <param name="primaryKey"></param>  
        /// <returns></returns>  
        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }


        /// <summary>  
        /// Gets a single record by the specified criteria (usually the unique identifier)  
        /// </summary>  
        /// <param name="predicate">Criteria to match on</param>  
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return DbSet.Single<TEntity>(predicate);
        }


        /// <summary>  
        /// The first record matching the specified criteria  
        /// </summary>  
        /// <param name="predicate">Criteria to match on</param>  
        /// <returns>A single record containing the first record matching the specified criteria</returns>  
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return DbSet.First<TEntity>(predicate);
        }
    }
}
