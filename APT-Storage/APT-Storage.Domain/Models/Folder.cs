﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.Domain.Models
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [DisplayName("Enter Folder Name")]
        public string Name { get; set; }

        [ForeignKey(nameof(User))]
        public int OwnerId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        public string FolderPath { get; set; }

        public ICollection<Subfolder>? Subfolders { get; set; }
        public ICollection<FileModel>? Files { get; set; }
    }
}
