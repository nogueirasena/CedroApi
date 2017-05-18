using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cedro.Restaurante.Service.ViewModels.Restaurante
{
    public class RestauranteViewModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo nome  obrigatorio")]
        [MaxLength(150,ErrorMessage = "Nome tem que ter no maximo 150 caracters")]
        public string Nome { get; set; }
    }
}