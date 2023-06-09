﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

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

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<FileModel>? Files { get; set; }
        public ICollection<Folder>? Folders { get; set; }
    }
}
