using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return Items;
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return Items.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Guid> AddItemAsync( string name, double price, string desc, Categories category)
        {
            var item = CreateItem(name, price, desc, category);
            Items.Add(item);

            return item.Id;
        }

        public async Task<Guid> UpdateItemAsync(Item newItem)
        {
            var index = Items.FindIndex(x => x.Id == newItem.Id);
            Items[index] = newItem;
            return newItem.Id;
        }
    }
}
