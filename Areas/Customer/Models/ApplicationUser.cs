using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FunlandV3.Areas.Customer.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string name { get; set; }
        public string StreetAddress { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}
