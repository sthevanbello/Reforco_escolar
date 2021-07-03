using Reforco_Escolar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reforco_Escolar.Repositories
{
    public interface IClienteRepository
    {
        Task<IList<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteUnicoAsync(int id);
        Task<Cliente> UpdateCadastroAsync(int id, Cliente cliente);
        Task IncluirClienteAsync(Cliente novoCliente);
        Task DeletarClienteAsync(int id);


    }
}