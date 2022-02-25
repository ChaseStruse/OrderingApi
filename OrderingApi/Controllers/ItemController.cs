using System;
using OrderingApi.Repositories;

namespace OrderingApi.Controllers
{
    public class ItemController
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository _itemRepository)
        {
            itemRepository = _itemRepository;
        }
    }
}
