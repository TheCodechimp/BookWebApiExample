using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.Shared;

namespace DataAccessRepository
{
    public abstract class IDataAccessRepository<TEntity> where TEntity : BaseEntity
    {
        private bool disposed = false;
        protected readonly IDbContext m_context;

        protected IDataAccessRepository(IDbContext context)
        {
            m_context = context;
        }

        public abstract void Add(TEntity record);
        public abstract void AddRange(IEnumerable<TEntity> records);
        public abstract Task<List<BookDataModel>> FindAll();
        public abstract TEntity Find(int id);
        public abstract BookDataModel FindLast();
        public abstract void Remove(int id);
        public abstract void RemoveRange(IEnumerable<int> idList);
        public abstract void Update(TEntity record);
        public abstract void Save();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    m_context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    //public interface IDataAccessRepository : IDisposable
    //{
    //    void Add<TEntity>(TEntity record);
    //    void AddRange<TEntity>(IEnumerable<TEntity> records);
    //    IEnumerable<TEntity> FindAll<TEntity>();
    //    TEntity Find<TEntity>(int id);
    //    void Remove<TEntity>(int id);
    //    void RemoveRange<TEntity>(IEnumerable<int> idList);
    //    void Update<TEntity>(TEntity record);
    //    void Save();
    //}
}
