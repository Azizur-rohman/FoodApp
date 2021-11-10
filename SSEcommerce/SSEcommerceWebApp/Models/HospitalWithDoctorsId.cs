using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class HospitalWithDoctorsId
    {
        public int Id { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        [ForeignKey("DoctorPersonalDetail")]
        public int DoctorPersonalDetailId { get; set; }
        public DoctorPersonalDetail DoctorPersonalDetail { get; set; }
    }
}
