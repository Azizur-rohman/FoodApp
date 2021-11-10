using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SSEcommerceWebApp.Enums;

namespace SSEcommerceWebApp.Models
{
    public class DoctorWorkingTime : BaseClass
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime WorkingTimeStart { get; set; }  

        [Required]
        [DataType(DataType.Time)]
        public DateTime WorkingTimeEnd { get; set; }

        public Week Week { get; set; }

        [ForeignKey("DoctorPersonalDetail")]
        public int DoctorPersonalDetailId { get; set; }
        public DoctorPersonalDetail DoctorPersonalDetail { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

    }
}
