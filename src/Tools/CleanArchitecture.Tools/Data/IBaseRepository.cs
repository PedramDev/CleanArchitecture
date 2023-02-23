using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Tools.Data
{
    /// <summary>
    /// یک ریپوزیتوری بهتر پیدا کنید که 
    /// IQueryable داشته باشد
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IBaseRepository<TEntity,TKey>
    {
        public Task<TKey> Add(TEntity entity);
        public Task Update(TEntity entity);
        public Task Delete(TEntity entity);
        public Task Delete(TKey entity);
        Task Get(TKey key);
    }
}
