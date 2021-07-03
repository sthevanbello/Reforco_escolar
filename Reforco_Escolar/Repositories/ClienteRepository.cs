using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _contextAccessor;

        public ClienteRepository(ApplicationContext context, IHttpContextAccessor contextAccessor) : base(context)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<IList<Cliente>> GetClientesAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Cliente> GetClienteUnicoAsync(int id)
        {
            var clienteDB = await dbSet.Where(c => c.Id == id).SingleOrDefaultAsync();

            
            return clienteDB;
        }

        public async Task<Cliente> UpdateCadastroAsync(int id, Cliente cliente)
        {
            var cadastroDB = dbSet.Where(c => c.Id == id).SingleOrDefault();

            if (cadastroDB == null)
            {
                await IncluirClienteAsync(cliente);
            }
            else
            {
                cadastroDB.Update(cliente);
            }
            await context.SaveChangesAsync();

            return cadastroDB;

        }

        public async Task IncluirClienteAsync(Cliente novoCliente)
        {
            if (novoCliente != null)
            {
                dbSet.Add(novoCliente);
                await context.SaveChangesAsync();
            }

        }

        public async Task DeletarClienteAsync(int id)
        {
            var clienteDB = dbSet.Where(c => c.Id == id).SingleOrDefault();

            if (clienteDB == null)
            {
                throw new ArgumentNullException("Não exite cliente cadastrado");
            }

            context.Remove(clienteDB);
            await context.SaveChangesAsync();
        }


        private int? GetClienteId()
        {
                var clienteId = _contextAccessor.HttpContext.Session.GetInt32("id");
            return clienteId;
        }

        private void SetClienteId(int clienteId)
        {
            _contextAccessor.HttpContext.Session.SetInt32("id", clienteId);
        }

    }
}
