using System;
using System.ComponentModel.DataAnnotations;

namespace PDMAngular.Models
{
    public class ItemType
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UserId { get; set; }
    }
}
