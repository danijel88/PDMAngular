using PDMAngular.Models;
using System.ComponentModel.DataAnnotations;

namespace PDMAngular.Controllers.Resources
{
    public class ItemResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string InternalCode { get; set; }

        public string Description { get; set; }

        public decimal? Band { get; set; }

        public decimal? Enter { get; set; }

        public decimal? Exit { get; set; }

        public decimal? Thickness { get; set; }

        public bool Elastic { get; set; }

        [Required]
        [StringLength(150)]
        public string MadeBy { get; set; }

        public string Color { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public int ItemTypeId { get; set; }

        public int MachineTypeId { get; set; }

        public Status Status { get; set; }

    }
}
