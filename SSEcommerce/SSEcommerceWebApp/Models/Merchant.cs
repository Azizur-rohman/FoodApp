using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Models
{
    public class Merchant
    {
      
        public string ServiceProvider { get; set; }
        public string Vertical { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ForeignKey("City")]
        public long CityId { get; set; }
        [ForeignKey("Address")]
        
        public Country Country { get; set; }
      /*  public City City { get; set; }
        public ICollection<Address> Addresses { get; set; }*/


        public string PostalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string AvgCost { get; set; }
        public string Menu { get; set; }

        public Nullable<bool> Agreed { get; set; }


    }

/*    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    } 
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    } 
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
    }*/
}
