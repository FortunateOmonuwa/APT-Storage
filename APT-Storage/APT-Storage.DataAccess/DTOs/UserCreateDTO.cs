using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.DataAccess.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        [MaxLength(20)]
        [DisplayName("Enter a Username")]
        public string? Username { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("FirstName")]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("LastName")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
