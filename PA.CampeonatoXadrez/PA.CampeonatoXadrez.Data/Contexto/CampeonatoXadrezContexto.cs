using PA.CampeonatoXadrez.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Data.Contexto
{
    public class CampeonatoXadrezContexto : DbContext
    {
        public CampeonatoXadrezContexto ()
            : base("BancoCampeonatoXadrez") { }

        public DbSet<Jogador> Jogadors { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Disable cascading deletion
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
