using System;
using System.Collections.Generic;
using System.Text;

namespace DotStarkTest.Data.Repository
{
    public interface IUnitOfWork
    {
        Repository<T> Repository<T>() where T : BaseEntity;
        void Save();
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly DotStarkDBContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;
        public UnitOfWork(DotStarkDBContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public Repository<T> Repository<T>() where T : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }
    }
}
