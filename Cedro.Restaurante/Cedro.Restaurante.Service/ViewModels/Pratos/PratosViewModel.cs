using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cedro.Restaurante.Service.ViewModels.Pratos
{
    public class PratosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatorio")]
        [MaxLength(150, ErrorMessage = "Nome tem que ter no maximo 150 caracters")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Todo prato precisa ter um restaurante relacionado")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Selecione um Restaurante")]
        public int IdRestaurante { get; set; }

        [Display(Name = "Nome do Restaurante")]
        public string NomeRestaurante { get; set; }
    }
}