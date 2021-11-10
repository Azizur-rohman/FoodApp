﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class Category : BaseClass
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }

    }
}