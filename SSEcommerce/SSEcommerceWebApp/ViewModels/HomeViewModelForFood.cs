using SSEcommerceWebApp.Models;
using System.Collections.Generic;

namespace SSEcommerceWebApp.ViewModels
{
    public class HomeViewModelForFood
    {
        public ICollection<SliderImage> SliderImages { get; set; }
        public ICollection<ApplicationUser> Restaurants { get; set; }


        public HomeViewModelForFood()
        {
            SliderImages = new List<SliderImage>();
            Restaurants = new List<ApplicationUser>();
        }
    }
}
