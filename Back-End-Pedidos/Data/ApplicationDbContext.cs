using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura las entidades
            modelBuilder.Entity<Produtos>()
                .HasKey(p => p.Id); // Clave primaria para Produto
        }
        public DbSet<Cliente> Clietes { get; set; }

        public DbSet<Pedidos>Pedidos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }





    



    }
}

