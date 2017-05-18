using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Restaurante.Dominio
{
    public class PratoObj
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public virtual RestauranteObj Restaurante { get; set; }
        public int IdRestaurante { get; set; }
    }
}
