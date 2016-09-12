using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClienteAPI.Models
{
        [Table("Clientes")]
        public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [MaxLength(300), Required]
        public string Nome { get; set; }
        [MaxLength(300), Required]
        public string Endereco { get; set; }

        [MaxLength(100), Required]
        public string Bairro { get; set; }

        [MaxLength(255), Required]
        public string Municipio { get; set; }

        [MaxLength(100), Required]
        public string Estado { get; set; }

        [MaxLength(30), Required]
        public string Cep { get; set; }

        [MaxLength(255), Required]
        public string Email { get; set; }

        [MaxLength(100), Required]
        public string sexo { get; set; }
    }
}