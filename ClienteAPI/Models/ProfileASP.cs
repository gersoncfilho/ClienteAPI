using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClienteAPI.Models
{
    [Table("ProfileASP")]
    public class ProfileASP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfile { get; set; }

        [MaxLength(50), Required]
        public string ProfileName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }
    }
}