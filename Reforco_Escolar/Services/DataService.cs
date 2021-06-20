using Reforco_Escolar.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reforco_Escolar.Services
{
    // Cria o banco caso não haja banco existente
    public class DataService : IDataService
    {
        private readonly ApplicationContext Context;

        public DataService(ApplicationContext context)
        {
            Context = context;
        }

        public void InicializaDB()
        {
            Context.Database.Migrate();
        }
    }
}
