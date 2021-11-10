using System.ComponentModel.DataAnnotations;

namespace SSEcommerceWebApp.ViewModels
{
    public class CustomerLoginViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
