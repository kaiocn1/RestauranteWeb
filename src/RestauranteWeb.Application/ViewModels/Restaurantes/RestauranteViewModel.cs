using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Application.ViewModels.Restaurantes
{
    public class RestauranteViewModel : ViewModelBase<Guid>
    {
        [Display(Name = "Nome do Restaurante", Description = "Nome do Restaurante")]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
        public string Descricao { get; set; }
    }
}
