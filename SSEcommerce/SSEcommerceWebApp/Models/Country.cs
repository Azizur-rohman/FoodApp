using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class Country : BaseClass
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Division> Divisions { get; set; }

        public ICollection<District> Districts { get; set; }

        public ICollection<Area> Areas { get; set; }

        public ICollection<Outlat> Outlats { get; set; }
    }
}
