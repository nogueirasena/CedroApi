using Cedro.Restaurante.Comum.Entity;
using Cedro.Restaurante.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Restaurante.AcessoDados.Entity.TypeConfiguration
{
    public class RestauranteTypeConfiguration : CedroRestauranteAbstractConfig<Dominio.RestauranteObj>
    {
        public RestauranteTypeConfiguration(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Nome)
                 .IsRequired()
                 .HasColumnName("Nome")
                 .HasMaxLength(150);
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            modelBuilder.Entity<RestauranteObj>()
             .HasMany(v => v.Pratos)
             .WithOptional()
             .WillCascadeOnDelete(true);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Restaurante");
        }
    }
}
