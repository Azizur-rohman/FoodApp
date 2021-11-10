﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class DoctorCertification : BaseClass
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("DoctorPersonalDetail")]
        public int DoctorPersonalDetailId { get; set; }
        public DoctorPersonalDetail DoctorPersonalDetail { get; set; }
    }
}
