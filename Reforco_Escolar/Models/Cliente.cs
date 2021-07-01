using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Models
{
    public class Cliente : BaseModel
    {


        [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Rua é obrigatório")]
        public string Rua { get; set; } = "";

        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Complemento é obrigatório")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; } = "";

        [Required(ErrorMessage = "Município é obrigatório")]
        public string Municipio { get; set; } = "";

        [Required(ErrorMessage = "UF é obrigatório")]
        public string UF { get; set; } = "";

        [Required(ErrorMessage = "CEP é obrigatório")]
        public string CEP { get; set; } = "";
        

        internal void Update(Cliente novoCliente)
        {
            Nome = novoCliente.Nome;
            Rua = novoCliente.Rua;
            Email = novoCliente.Email;
            Telefone = novoCliente.Telefone;
            Complemento = novoCliente.Complemento;
            Bairro = novoCliente.Bairro;
            Municipio = novoCliente.Municipio;
            UF = novoCliente.UF;
            CEP = novoCliente.CEP;

        }


        
    }
}
