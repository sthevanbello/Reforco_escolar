using Microsoft.EntityFrameworkCore;
using Reforco_Escolar.Context;
using Reforco_Escolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Repositories
{

    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
    }

}
