using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.Domain.Models
{
    public class Subfolder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        public string FolderPath { get; set; }
        [ForeignKey(nameof(Folder))]
        public int ParentFolderId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<FileModel>? Files { get; set; }
    }
}
