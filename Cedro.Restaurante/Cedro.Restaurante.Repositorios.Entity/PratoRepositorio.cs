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
    public class PratoRepositorio : RepositorioGenericoEntity<PratoObj, int>
    {
        public override List<PratoObj> Selecionar()
        {
            return Contexto.Set<PratoObj>().Include(p => p.Restaurante).ToList();
        }

        public override PratoObj SelectionarPorId(int id)
        {
            return Contexto.Set<PratoObj>().Include(p => p.Restaurante).SingleOrDefault(p => p.Id == id);
        }
    }
}
