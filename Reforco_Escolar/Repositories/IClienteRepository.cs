using Reforco_Escolar.Models;
using System.Collections.Generic;

namespace Reforco_Escolar.Repositories
{
    public interface IClienteRepository
    {
        IList<Cliente> GetClientes();
        void Update(Cliente cliente);
        void IncluirCliente(Cliente novoCliente);
    }
}