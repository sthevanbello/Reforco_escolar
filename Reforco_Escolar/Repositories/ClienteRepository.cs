using Microsoft.EntityFrameworkCore;
using Reforco_Escolar.Context;
using Reforco_Escolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationContext context;
        private readonly DbSet<Cliente> dbSet;


        public ClienteRepository(ApplicationContext context)
        {
            this.context = context;
            dbSet = context.Set<Cliente>();
        }

        public IList<Cliente> GetClientes()
        {
            return dbSet.ToList();
        }

        public async void Update(Cliente novoCliente)
        {
            var cadastroDB =
                await dbSet.Where(c => c.Id == novoCliente.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDB.Update(novoCliente);
            await context.SaveChangesAsync();
            
        }
    }
}
