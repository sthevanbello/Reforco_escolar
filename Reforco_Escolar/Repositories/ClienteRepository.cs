using Microsoft.EntityFrameworkCore;
using Reforco_Escolar.Context;
using Reforco_Escolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(ApplicationContext context) : base(context)
        {

        }

        public IList<Cliente> GetClientes()
        {
            return dbSet.ToList();
        }

        public Cliente UpdateCadastro(Cliente cliente)
        {
            var cadastroDB = dbSet.Where(c => c.Id == cliente.Id).SingleOrDefault();

            if (cadastroDB == null)
            {
                IncluirCliente(cliente);
            }
            else
            {
                cadastroDB.Update(cliente);
            }
            context.SaveChangesAsync();

            return cliente;

        }

        public void IncluirCliente(Cliente novoCliente)
        {
            if (novoCliente != null)
            {
                dbSet.Add(novoCliente);
                context.SaveChanges();
            }

        }

        public void DeletarCliente(Cliente cliente)
        {
            var cadastroDB = dbSet.Where(c => c.Id == cliente.Id).SingleOrDefault();

            if (cliente == null)
            {
                throw new ArgumentNullException("Não exite cliente cadastrado");
            }

            context.Remove(cliente);
            context.SaveChanges();

        }


    }
}
