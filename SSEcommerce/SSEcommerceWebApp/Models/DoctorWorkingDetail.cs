using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace SSEcommerceWebApp.Models
{
    public class DoctorWorkingDetail : BaseClass
    {
        public int Id { get; set; }

        [Required]
        public string HospitalName { get; set; }

        [Required]
        public string ServiceCharge { get; set; }

        [Required]
        public string WorkingTime { get; set; }
    }
}
