﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderingApi.Models;
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

        [HttpGet]
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return null;
        }
    }
}
