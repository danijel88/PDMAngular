﻿using PDMAngular.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Core
{
    public interface IItemRepository
    {
        Task<Item> GetItem(int id, bool includeRelated = true);
        Task<IEnumerable<Item>> GetItems(ItemQuery filter);

        void Add(Item item);

        void Remove(Item item);
    }
}