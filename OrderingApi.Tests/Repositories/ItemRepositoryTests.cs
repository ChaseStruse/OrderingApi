using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using OrderingApi.Enums;
using OrderingApi.Models;
using OrderingApi.Repositories;
using Xunit;

namespace OrderingApi.Tests
{
    public class ItemRepositoryTests
    {
        private readonly IItemRepository _sut;

        public ItemRepositoryTests()
        {
            _sut = new ItemRepository();
        }

        [Fact]
        public async void GetItemsAsync_ReturnsAllItems()
        {
            var actual = await _sut.GetItemsAsync();

            var expected = new List<Item>()
            {
                CreateItem(actual.Where(x => x.Name == "TestName 1").FirstOrDefault().Id,"TestName 1", 10, "TestDescription 1", Categories.Cleaning),
                CreateItem(actual.Where(x => x.Name == "TestName 2").FirstOrDefault().Id,"TestName 2", 11, "TestDescription 2", Categories.Clothing),
                CreateItem(actual.Where(x => x.Name == "TestName 3").FirstOrDefault().Id,"TestName 3", 12.5, "TestDescription 3", Categories.Grocery),
                CreateItem(actual.Where(x => x.Name == "TestName 4").FirstOrDefault().Id,"TestName 4", 13.75, "TestDescription 4", Categories.Sanitary)
            };

            actual.Should().NotBeNull().And.Equal(expected);
        }

        [Fact]
        public async void GetItemAsync_ReturnsItem()
        {
            var items = await _sut.GetItemsAsync();

            var expected = items.First();
            var actual = await _sut.GetItemAsync(expected.Id);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void AddItemAsync_CreatesItem()
        {
            string name = "TestName 5";
            double price = 100;
            string desc = "TestDescription 5";

            var id = await _sut.AddItemAsync(name, price, desc, Categories.Grocery);

            var actual = await _sut.GetItemAsync(id);
            var expected = CreateItem(id, name, price, desc, Categories.Grocery);
        }

        [Fact]
        public async void UpdateItemAsync_UpdatesItem()
        {
            string name = "TestName 6";
            double price = 100;
            string desc = "TestDescription 6";

            
            var items = await _sut.GetItemsAsync();

            var originalItem = items.First();
            var expectedItem = CreateItem(originalItem.Id, name, price, desc, Categories.Sanitary);
            var newItem = await _sut.UpdateItemAsync(expectedItem);
            
        }

        [Fact]
        public async void DeleteItemAsync_DeletesItem()
        {
            var items = await _sut.GetItemsAsync();
            var itemToDelete = items.Where(x => x.Name == "TestName 3").FirstOrDefault();

            await _sut.DeleteItemAsync(itemToDelete);

            var actual = await _sut.GetItemsAsync();
            actual.Should().NotBeEquivalentTo(items).And.HaveCountLessThan(items.Count());
        }

        private static Item CreateItem(Guid? id, string name, double price, string description, Categories category)
        {
            var item = new Item
            {
                Id = (Guid)(id is null ? Guid.NewGuid() : id),
                Name = name,
                Price = price,
                Description = description,
                Category = category
            };

            return item;
        }
    }
}
