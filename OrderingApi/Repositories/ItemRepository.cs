using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingApi.Enums;
using OrderingApi.Models;

namespace OrderingApi.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private List<Item> Items = new List<Item>
        {
            CreateItem("TestName 1", 10, "TestDescription 1", Categories.Cleaning),
            CreateItem("TestName 2", 11, "TestDescription 2", Categories.Clothing),
            CreateItem("TestName 3", 12.5, "TestDescription 3", Categories.Grocery),
            CreateItem("TestName 4", 13.75, "TestDescription 4", Categories.Sanitary)
        };

        public ItemRepository()
        {
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return Items;
        }

        private static Item CreateItem(string name, double price, string description, Categories category)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Description = description,
                Category = category
            };

            return item;
        }
    }
}
