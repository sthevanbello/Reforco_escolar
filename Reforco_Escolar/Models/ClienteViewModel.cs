using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Models
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }
        

        public ClienteViewModel(Cliente cliente)
        {
            Cliente = cliente;
        }


    }
}
