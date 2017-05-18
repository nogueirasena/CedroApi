using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Restaurante.Repositorios.Comum
{
    public interface IRepositoriosGenerico<TEntidade, TChave>
        where TEntidade : class
    {
        List<TEntidade> Selecionar();
        TEntidade SelectionarPorId(TChave id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        void Inserir(TEntidade entidade);
        void Alterar(TEntidade entidade);
        void Excluir(TEntidade entidade);
        void ExcluirPorId(TChave id);
        void ExcluiDependentes(List<TEntidade> TEntidades);
    }
}
