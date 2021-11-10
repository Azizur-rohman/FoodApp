using System;
using System.ComponentModel.DataAnnotations;

namespace SSEcommerceWebApp.Models
{
    public class BaseClass
    {
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }  

        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }


        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
