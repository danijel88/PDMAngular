using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PDMAngular.Core.Models
{
    public class ItemType
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UserId { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<ItemHist> ItemHists { get; set; }

        public ItemType()
        {
            Items = new Collection<Item>();
            ItemHists = new Collection<ItemHist>();
        }
    }
}
