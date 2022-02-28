using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingApi.Models;

namespace OrderingApi.Controllers
{
    public interface IItemController
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid id);
    }
}
