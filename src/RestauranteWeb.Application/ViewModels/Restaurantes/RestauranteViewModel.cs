using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Application.ViewModels.Restaurantes
{
    public class RestauranteViewModel : ViewModelBase<Guid>
    {
        [Display(Name = "Descrição", Description = "Descrição")]
        [Required(ErrorMessage = "{0} é obrigatória.")]
        [StringLength(100, ErrorMessage = "A {0} deve ter no máximo {1} caracteres.")]
        public string Descricao { get; set; }
    }
}
