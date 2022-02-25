using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using OrderingApi.Controllers;
using OrderingApi.Enums;
using OrderingApi.Models;
using OrderingApi.Repositories;
using Xunit;

namespace OrderingApi.Tests.Controllers
{
    public class ItemControllerTests
    {
        private ItemController _sut;
        private readonly Mock<IItemRepository> _repository;

        [Fact]
        public async void GetItems_ReturnsListOfItems()
        {
            var expected = new[]
            {
                CreateItem("Test1", 10, "Test desc 1", Categories.Cleaning),
                CreateItem("Test2", 12.2, "Test desc 2", Categories.Clothing),
                CreateItem("Test3", 13.3, "Test desc 3", Categories.Grocery),
                CreateItem("Test4", 14.4, "Test desc 4", Categories.Sanitary)
            };

            _repository.Setup(x => x.GetItemsAsync()).ReturnsAsync(expected);

            _sut = new ItemController(_repository.Object);

            var actual = _sut.GetItemsAsync();

            actual.Should().BeEquivalentTo(expected);
        }

        private Item CreateItem(string name, double price, string desc, Categories category)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Description = desc,
                Category = category
            };

            return item;
        }

    }
}
