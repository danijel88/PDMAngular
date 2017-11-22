using System;

namespace PDMAngular.Controllers.Resources
{
    public class ItemTypeResource
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UserId { get; set; }
    }
}
