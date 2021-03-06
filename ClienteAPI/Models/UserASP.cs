﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClienteAPI.Models
{
    /// <summary>
    /// Tabela usuarios Seu Paulo Protetor
    /// </summary>
    [Table("UsersASP")]
    public class UserAsp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }

        [MaxLength(50), Required]
        public string Username { get; set; }

        [MaxLength(50), Required]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int ProfileId { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }
    }
}
