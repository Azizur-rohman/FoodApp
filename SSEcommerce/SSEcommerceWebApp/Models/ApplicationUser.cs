using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace SSEcommerceWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "First Name")]
        public string FirstName { get; set; }   
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }

        [Display(Name = "Restaurant Type")]
        public int RestaurantTypeId { get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPersonName { get; set; }

        [Display(Name = "NID/rade License)")]
        public string NidImagePath { get; set; }

        [NotMapped] 
        [Display(Name = "NID or Trade License (Image)")]
        public IFormFile NidImage { get; set; }

        [Display(Name = "Menu")]

        public string MenuImagePath { get; set; }
        [NotMapped] 
        [Display(Name = "Upload Menu (PDF or Image)")]
        public IFormFile MenuImage { get; set; }    
        
        [Display(Name = "Restaurant Image")]
        public string RestaurantImagePath { get; set; }

        [NotMapped] 
        [Display(Name = "Restaurant Image")]
        public IFormFile RestaurantImage { get; set; }

        [Display(Name = "Restaurant Logo")]
        public string LogoPath { get; set; }
        [NotMapped] 
        [Display(Name = "Restaurant Logo")]
        public IFormFile RestaurantLogo { get; set; }
        
        [Display(Name = "User Image")]
        public string UserImagePath { get; set; }
        [NotMapped] 
        [Display(Name = "User Image")]
        public IFormFile UserImage { get; set; }

        [Display(Name = "Facebook Page")]
        public string FacebookPageLink { get; set; }  
        
        public string Address { get; set; }

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

        [Display(Name = "Availability Status")]
        //Online or Offline
        public bool IsAvailable { get; set; }

        [Display(Name = "Approval Status")]
        public bool IsApproved { get; set; }

        public ICollection<Product> Products { get; set; }

        [Display(Name="Main Branch")]
        public string VendorParentId { get; set; }
        public ApplicationUser VendorApplicationUser { get; set; }
        public DoctorPersonalDetail DoctorPersonalDetail { get; set; }


        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11,ErrorMessage = "The phone number must be 11 digits.")]
        [MaxLength(11, ErrorMessage = "The phone number must 11 digits.")]
        public override string PhoneNumber { get; set; }

        //[Required]    
        [EmailAddress]
        public override string Email { get; set; }


        public double UserPoints { get; set; }
        public ApplicationUser()
        {
            Products = new List<Product>();
        }
        
    }
}

