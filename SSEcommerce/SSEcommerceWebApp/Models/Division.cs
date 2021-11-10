using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class Division : BaseClass
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}
