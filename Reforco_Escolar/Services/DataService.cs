using Reforco_Escolar.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reforco_Escolar.Repositories;

namespace Reforco_Escolar.Services
{
    // Cria o banco caso não haja banco existente
    public class DataService : IDataService
    {
        private readonly ApplicationContext _context;
        private readonly IClienteRepository _clienteRepository;


        public DataService(ApplicationContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        public void InicializaDB()
        {
            _context.Database.Migrate();
        }



    }
}
