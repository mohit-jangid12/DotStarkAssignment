using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotStarkTest.Data.Repository
{
    public class Repository<T> where T : BaseEntity
    {
        private readonly DotStarkDBContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(DotStarkDBContext context)
        {
            this.context = context;
        }
        
        public T GetById(object Id)
        {
            return this.Entities.Find(Id);
        }
        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw new Exception(errorMessage, dbEx);
            }
        }
        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw new Exception(errorMessage, dbEx);
            }
        }
        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw new Exception(errorMessage, dbEx);
            }
        }
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
        private DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }
    }
}
