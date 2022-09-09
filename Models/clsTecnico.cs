using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CADASTRO_DE_CLUBE_DE_FUTEBOL.Models
{
    public class clsTecnico : clsPessoa
    {
        [Display(Name = "Quantidade de títulos:*")]

        [Required(ErrorMessage = "Informar quantidade de Títulos ganhos!")]
        public int qtdTitulos { get; set; }

        [Display(Name = "Quantos times já passou:*")]
        [Required(ErrorMessage = "Informar quantidade de Títulos ganhos!")]
        public int qtdTimes { get; set; }

        [Display(Name = "Qual sua estratégia:*")]
        [Required(ErrorMessage = "Informar sua estratégia!")]
        public string estrategia {get; set;}
    }

}