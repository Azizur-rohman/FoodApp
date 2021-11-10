using System.ComponentModel.DataAnnotations;

namespace SSEcommerceWebApp.Enums
{
    public enum RestaurantType
    {
        Restaurant =1,
        [Display(Name="Homechef")]
        HomeChef=2
    }   
}
