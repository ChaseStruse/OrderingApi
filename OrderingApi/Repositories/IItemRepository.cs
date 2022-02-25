using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingApi.Enums;
using OrderingApi.Models;

namespace OrderingApi.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid id);
        Task<Guid> AddItemAsync(string name, double price, string desc, Categories category);
    }
}
