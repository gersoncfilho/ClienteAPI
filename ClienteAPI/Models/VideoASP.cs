using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClienteAPI.Models
{
    [Table("VideosASP")]
    public class VideoASP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVideo { get; set; }

        [Required, MaxLength(50)]
        public string VideoTitle { get; set; }

        [Required, MaxLength(100)]
        public string VideoDescription { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }
    }
}