using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Models
{
    public class Cadastro
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public string Rua { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public string Complemento { get; set; } = "";
        [Required]
        public string Bairro { get; set; } = "";
        [Required]
        public string Municipio { get; set; } = "";
        [Required]
        public string UF { get; set; } = "";
        [Required]
        public string CEP { get; set; } = "";
    }
}
