using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderingApi.Models;
using OrderingApi.Repositories;

namespace OrderingApi.Controllers
{
    public class ItemController : IItemController
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository _itemRepository)
        {
            itemRepository = _itemRepository;
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = await itemRepository.GetItemAsync(id);
            return item;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            var items = await itemRepository.GetItemsAsync();
            return items;
        }
    }
}
