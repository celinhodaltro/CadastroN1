using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Um valor é necessario.")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d*(\.\d{0,2})?$", ErrorMessage = "O {0} está invalido, O campo deve ser inserido no seguinte formato: (0.00)")]
        public string InputValue { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Um valor é necessario.")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]

        public decimal Value { get; set; }

        [Display(Name = "Disponivel")]
        public bool Available { get; set; }

        [Required(ErrorMessage = "Um cliente é necessario.")]
        [Display(Name = "Cliente")]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }



    }
}
