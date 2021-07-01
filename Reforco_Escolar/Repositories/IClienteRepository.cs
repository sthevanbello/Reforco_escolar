using Reforco_Escolar.Models;
using System.Collections.Generic;

namespace Reforco_Escolar.Repositories
{
    public interface IClienteRepository
    {
        IList<Cliente> GetClientes();
        Cliente GetClienteUnico(int id);
        Cliente UpdateCadastro(int id, Cliente cliente);
        void IncluirCliente(Cliente novoCliente);
        void DeletarCliente(int id);


    }
}