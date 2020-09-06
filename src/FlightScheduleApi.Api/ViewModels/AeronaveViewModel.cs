using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightScheduleApi.Api.ViewModels
{
    public class AeronaveViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Matrícula")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(5, ErrorMessage = "O campo {0} precisa ter 5 caracteres.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 1)]
        public string Fabricante { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 1)]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 1)]
        public string Modelo { get; set; }
    }
}
