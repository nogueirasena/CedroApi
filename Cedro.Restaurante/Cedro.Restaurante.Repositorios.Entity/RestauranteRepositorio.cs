using Cedro.Restaurante.AcessoDados.Entity.Context;
using Cedro.Restaurante.Dominio;
using Cedro.Restaurante.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cedro.Restaurante.Repositorios.Entity
{
    public class RestauranteRepositorio : RepositorioGenericoEntity<Dominio.RestauranteObj, int>
    {
        public override List<Dominio.RestauranteObj> Selecionar()
        {
            return Contexto.Set<RestauranteObj>().Include(p => p.Pratos).ToList();
        }

        public override RestauranteObj SelectionarPorId(int id)
        {
            return Contexto.Set<RestauranteObj>().Include(p => p.Pratos).SingleOrDefault(p => p.Id == id);
        }
    }
}
