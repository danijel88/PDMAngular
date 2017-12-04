using PDMAngular.Core.Models;
using System;

namespace PDMAngular.Controllers.Resources
{
    public class ItemResource
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

        public KeyValuePairResource ItemType { get; set; }

        public MachineTypeResource MachineType { get; set; }

        public Status Status { get; set; }

    }
}
