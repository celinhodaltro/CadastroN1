using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O sobrenome é requerido.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "O email é requerido.")]
        public int AvailableQuantity { get; set; }

        [Required(ErrorMessage = "Um cliente é necessario.")]
        public List<ClientViewModel> ClientList { get; set; }
    }
}
