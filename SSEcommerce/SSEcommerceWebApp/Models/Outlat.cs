using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class Outlat : BaseClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Addressline { get; set; }

        public string ContactNumber { get; set; }

        public string ContactPerson { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Image { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [ForeignKey("Division")]
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        [ForeignKey("District")]
        public int DistrictId { get; set; }
        public District District { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public Area Area { get; set; }


    }
}
