﻿using System.ComponentModel.DataAnnotations;

namespace PDMAngular.Controllers.Resources
{
    public class KeyValuePairResource
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        public string UserId { get; set; }
    }
}
