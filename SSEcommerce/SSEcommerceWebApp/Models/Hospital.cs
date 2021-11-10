using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class Hospital : BaseClass
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }

        public int Phonenumber { get; set; }

        public string Email { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<DoctorPersonalDetail> DoctorPersonalDetails { get; set; }

        public ICollection<DoctorServiceCharge> DoctorServiceCharges { get; set; }

    }
}
