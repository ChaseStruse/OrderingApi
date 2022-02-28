using System;
using System.Collections;
using System.Collections.Generic;
using Bogus;
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
        private IItemController _sut;
        private Mock<IItemRepository> _repository;


        [Fact]
        public async void GetItems_ReturnsListOfItems()
        {
            _repository = new Mock<IItemRepository>();
            List<Item> expected = new Faker<List<Item>>();

            _repository.Setup(x => x.GetItemsAsync()).ReturnsAsync(expected);

            _sut = new ItemController(_repository.Object);

            var actual = await _sut.GetItemsAsync();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void GetItem_ReturnsItem()
        {
            _repository = new Mock<IItemRepository>();
            Item expected = new Faker<Item>();
            _repository.Setup(x => x.GetItemAsync(It.IsAny<Guid>())).ReturnsAsync(expected);

            _sut = new ItemController(_repository.Object);
            var actual = await _sut.GetItemAsync(expected.Id);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
