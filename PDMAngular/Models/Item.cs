using System;
using System.ComponentModel.DataAnnotations;

namespace PDMAngular.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string InternalCode { get; set; }

        public string Description { get; set; }

        public int? Band { get; set; }

        public int? Enter { get; set; }

        public int? Exit { get; set; }

        public int? Thickness { get; set; }

        [Required]
        [StringLength(150)]
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




    }
}
