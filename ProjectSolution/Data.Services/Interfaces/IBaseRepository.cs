using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);

        T GetById(string id);

        void Insert(T entity);

        Task InsertAndSaveAsync(T entity);

        void Remove(string id);

        Task RemoveAndSaveAsync(string id);

        Task SaveChangesAsync();

        void Update(T entity);

        Task UpdateAndSaveAsync(T entity);
    }
}
