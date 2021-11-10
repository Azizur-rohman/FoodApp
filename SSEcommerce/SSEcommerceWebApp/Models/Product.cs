using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace SSEcommerceWebApp.Models
{
    public class Product : BaseClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "User Image")]
        public string ImagePath { get; set; }
        [NotMapped] 
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }


        public string Description { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }


        [Display(Name="Has Qty")]
        public bool HasQuantity { get; set; }


        [Display(Name="Available")]
        public bool IsAvailable { get; set; }

        [ForeignKey("SubCategory")]
        [Display(Name="Sub-Category")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public int CategoryId { get; set; }
    }
}
