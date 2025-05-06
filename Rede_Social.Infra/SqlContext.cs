using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedeSocial.Domain;

namespace Rede_Social.Infra
{
    public class SqlContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }    
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postages { get; set; }
        
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=navarro;Username=postgres;Password=12345;");
        }

        /*
         * protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             // Configure a string de conexão com o SQL Server LocalDB
             optionsBuilder.UseSqlServer(
                 "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TESTEREDE;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
         }
        */
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          

            modelBuilder.Entity<Postagem>().ToTable("Postagens");
            modelBuilder.Entity<Evento>().ToTable("Eventos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

        }


    }
}