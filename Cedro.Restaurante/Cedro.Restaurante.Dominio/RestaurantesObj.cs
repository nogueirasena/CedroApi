using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Restaurante.Dominio
{
    public class RestauranteObj
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// A lista de pratos do restaurante.
        /// </summary>
        public virtual List<PratoObj> Pratos { get; set; }
    }
}
