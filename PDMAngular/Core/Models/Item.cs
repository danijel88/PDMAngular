using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PDMAngular.Core.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string InternalCode { get; set; }

        public string Description { get; set; }

        public decimal? Band { get; set; }

        public decimal? Enter { get; set; }

        public decimal? Exit { get; set; }

        public decimal? Thickness { get; set; }

        public bool Elastic { get; set; }

        public string MadeBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string Color { get; set; }

        public string Name { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UserId { get; set; }

        public ItemType ItemType { get; set; }

        public int ItemTypeId { get; set; }

        public MachineType MachineType { get; set; }

        public int MachineTypeId { get; set; }

        public Status Status { get; set; }

        public ICollection<ItemHist> ItemHists { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public Item()
        {
            ItemHists = new Collection<ItemHist>();
            Photos = new Collection<Photo>();
        }

    }
}
