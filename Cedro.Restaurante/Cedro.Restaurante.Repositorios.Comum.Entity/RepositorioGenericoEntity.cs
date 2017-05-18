using Cedro.Restaurante.AcessoDados.Entity.Context;
using Cedro.Restaurante.Repositorios.Comum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Restaurante.Repositorios.Comum.Entity
{
    public class RepositorioGenericoEntity<TEntidade, TChave> : IRepositoriosGenerico<TEntidade, TChave>
        where TEntidade : class
    {
        private RestauranteDbContext _contexto;

        public RestauranteDbContext Contexto
        {
            get
            {
                if (_contexto == null)
                {
                    _contexto = new RestauranteDbContext();
                }

                return _contexto;
            }
        }

        public void Alterar(TEntidade entidade)
        {
            Contexto.Set<TEntidade>().Attach(entidade);
            Contexto.Entry(entidade).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        public void Excluir(TEntidade entidade)
        {
            Contexto.Set<TEntidade>().Attach(entidade);
            Contexto.Entry(entidade).State = EntityState.Deleted;
            Contexto.SaveChanges();
        }

        public void ExcluirPorId(TChave id)
        {
            TEntidade entidade = Contexto.Set<TEntidade>().Find(id);
            Contexto.Set<TEntidade>().Attach(entidade);
            Contexto.Entry(entidade).State = EntityState.Deleted;
            Contexto.SaveChanges();
        }

        public void Inserir(TEntidade entidade)
        {
            Contexto.Set<TEntidade>().Add(entidade);
            Contexto.SaveChanges();
        }

        public virtual List<TEntidade> Selecionar()
        {
            return Contexto.Set<TEntidade>().ToList();
        }

        public virtual TEntidade SelectionarPorId(TChave id)
        {
            return Contexto.Set<TEntidade>().Find(id);
        }

        public virtual void ExcluiDependentes(List<TEntidade> TEntidades)
        {

            foreach (var item in TEntidades)
            {
                Contexto.Set<TEntidade>().Attach(item);
                Contexto.Entry(item).State = EntityState.Deleted;
                Contexto.SaveChanges();

            }
        }
    }
}