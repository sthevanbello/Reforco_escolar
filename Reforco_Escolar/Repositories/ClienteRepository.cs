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

        public IList<Cliente> GetClientes()
        {
            return dbSet.ToList();
        }

        public Cliente GetClienteUnico(int id)
        {
            var clienteDB = dbSet.Where(c => c.Id == id).SingleOrDefault();

            
            return clienteDB;
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

        public void DeletarCliente(int id)
        {
            var clienteDB = dbSet.Where(c => c.Id == id).SingleOrDefault();

            if (clienteDB == null)
            {
                throw new ArgumentNullException("Não exite cliente cadastrado");
            }

            context.Remove(clienteDB);
            context.SaveChanges();

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
