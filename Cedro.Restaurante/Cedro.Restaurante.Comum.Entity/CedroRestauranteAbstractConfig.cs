using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Restaurante.Comum.Entity
{
    public abstract class CedroRestauranteAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
		where TEntidade : class
    {
        protected DbModelBuilder modelBuilder;

        public CedroRestauranteAbstractConfig(DbModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
            ConfigurarNomeTabela();
            ConfigurarCamposTabela();
            ConfigurarChavePrimaria();
            ConfigurarChavesEstrangeiras();
        }

        protected abstract void ConfigurarChavesEstrangeiras();


        protected abstract void ConfigurarChavePrimaria();


        protected abstract void ConfigurarCamposTabela();


        protected abstract void ConfigurarNomeTabela();
    }
}