using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeCarros.Models
{
    public class CarroViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo Carro é obrigatorio.")]
        [Display(Name = "Marca do Carro")]
        public string Marca { get; set; }
        [Required]
        [Display(Name = "Modelo do Carro")]
        public string Modelo { get; set; }
        [Required]
        [Display(Name = "Ano")]
        public string Ano { get; set; }
        [Required]
        [Display(Name = "A cor do Carro")]
        public string Cor { get; set; }
        [Required]
        [Display(Name = "A foto do carro")]
        public string Foto { get; set; }
        
    }
}
