using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.API.Services
{
    public interface IDataRepository<T>
    {
        Task<T> GetItemAsync(string id);

        Task<IEnumerable<T>> GetItemsAsync();

        Task<bool> AddItemAsync(T item);

        Task<bool> UpdateItemAsync(T item);

        Task<bool> DeleteItemAsync(string id);
    }
}
