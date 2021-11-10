using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class DoctorPersonalDetail : BaseClass
    {
        public int Id { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }

        public ICollection<Hospital> Hospitals { get; set; }

        public ICollection<DoctorSpecialist> DoctorSpecialists { get; set; }

        public ICollection<DoctorCertification> DoctorCertifications { get; set; }

        public ICollection<DoctorServiceCharge> DoctorServiceCharges { get; set; }

        public ICollection<DoctorWorkingTime> DoctorWorkingTimes { get; set; }
    }
}
