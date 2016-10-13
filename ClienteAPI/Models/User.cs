using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClienteAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(300), Required]
        public string Username { get; set; }

        [MaxLength(300), Required]
        public string FirstName { get; set; }

        [MaxLength(300), Required]
        public string LastName { get; set; }

        [MaxLength(300), Required]
        public string Email { get; set; }

        [MaxLength(300), Required]
        public string Password { get; set; }

        [MaxLength(50), Required]
        public string Phone { get; set; }
    }
}