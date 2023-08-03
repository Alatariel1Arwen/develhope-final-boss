using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Develhope.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetNotExpiredAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteByIdAsync(int id);
    }
}