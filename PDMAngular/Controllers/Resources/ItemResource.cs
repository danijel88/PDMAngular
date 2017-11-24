using PDMAngular.Models;
using System;

namespace PDMAngular.Controllers.Resources
{
    public class ItemResource
    {
        public int Id { get; set; }

        public string InternalCode { get; set; }

        public string Description { get; set; }

        public int? Band { get; set; }

        public int? Enter { get; set; }

        public int? Exit { get; set; }

        public int? Thickness { get; set; }

        public bool Elastic { get; set; }

        public string MadeBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string Color { get; set; }

        public string Name { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UserId { get; set; }


        public int ItemTypeId { get; set; }


        public int MachineTypeId { get; set; }

        public Status Status { get; set; }

    }
}
