using Microsoft.AspNetCore.Identity;
using Microsoft.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? ContactNo { get; set; }
        
        [Required]
        public string? Role { get; set; }
        [Required]
        public string? HCRNo { get; set; }
        [NotMapped]
        public string Password { get; set; }


    }
}
