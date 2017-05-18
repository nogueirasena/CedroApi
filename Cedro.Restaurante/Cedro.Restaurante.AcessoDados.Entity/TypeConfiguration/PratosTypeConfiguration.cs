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
    public class PratosTypeConfiguration : CedroRestauranteAbstractConfig<PratoObj>
    {
        public PratosTypeConfiguration(DbModelBuilder modelBuilder) : base(modelBuilder)
        { }

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

            Property(p => p.Preco)
                .IsRequired()
                .HasColumnName("Preco");

            Property(p => p.IdRestaurante)
                .HasColumnName("IdRestaurante")
                .IsRequired();

        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasRequired(p => p.Restaurante)
                .WithMany(p => p.Pratos)
                .HasForeignKey(fk => fk.IdRestaurante);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Prato");
        }
    }
}