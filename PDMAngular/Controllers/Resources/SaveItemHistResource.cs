using PDMAngular.Core.Models;

namespace PDMAngular.Controllers.Resources
{
    public class SaveItemHistResource
    {

        public string InternalCode { get; set; }

        public string Description { get; set; }

        public decimal? Band { get; set; }

        public decimal? Enter { get; set; }

        public decimal? Exit { get; set; }

        public decimal? Thickness { get; set; }

        public bool Elastic { get; set; }

        public string MadeBy { get; set; }

        public string Color { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public int ItemTypeId { get; set; }

        public int MachineTypeId { get; set; }

        public Status Status { get; set; }
    }
}
