using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.Domain.Models
{
    public class FileModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [DisplayName("Enter File Name")]
        public string FileName { get; set; }

        [Range(0, 5L * 1024 * 1024, ErrorMessage = "file size too large")]
        public long FileSize { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(User))]
        public int OwnerId { get; set; }
    }
}
