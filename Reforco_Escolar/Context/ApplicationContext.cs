using Microsoft.EntityFrameworkCore;
using Reforco_Escolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            
            
            
        }
    }
}

//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    base.OnModelCreating(modelBuilder);
//    modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
//    modelBuilder.Entity<Cliente>().HasOne(c => c.Cadastro);


//    modelBuilder.Entity<Cadastro>().HasKey(c => c.Id);
//    modelBuilder.Entity<Cadastro>().HasOne(c => c.Cliente).WithOne(c => c.Cadastro).HasForeignKey<Cliente>(c => c.Id).IsRequired();


//}