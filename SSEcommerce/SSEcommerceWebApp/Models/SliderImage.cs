using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace SSEcommerceWebApp.Models
{
    public class SliderImage:BaseClass
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public string ActionUrl { get; set; }
        
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}