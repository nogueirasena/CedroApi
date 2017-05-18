// -----------------------------------------------------------------------
// <copyright file="RestauranteDbContext.cs" company="">
//     Copyright © xpto. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
// -----------------------------------------------------------------------

using Cedro.Restaurante.AcessoDados.Entity.TypeConfiguration;
using Cedro.Restaurante.Dominio;
using System.Data.Entity;

namespace Cedro.Restaurante.AcessoDados.Entity.Context
{
    public class RestauranteDbContext : DbContext
    {
        public DbSet<Dominio.RestauranteObj> Restaurantes { get; set; }
        public DbSet<PratoObj> Pratos { get; set; }

        public RestauranteDbContext()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RestauranteTypeConfiguration(modelBuilder));
            modelBuilder.Configurations.Add(new PratosTypeConfiguration(modelBuilder));
        }
    }
}