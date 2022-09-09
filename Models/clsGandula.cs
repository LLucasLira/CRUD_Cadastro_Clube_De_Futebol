using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CADASTRO_DE_CLUBE_DE_FUTEBOL.Models
{
    public class clsGandula : clsPessoa
    {

        [Display(Name="Jogos Trabalhados:*")]
        [Required (ErrorMessage="Informe quantos jogos ele(a) participou!")]
        public int jogosTrabalhados { get; set; }

        [Display(Name="Jogos Vencidos:*")]
        [Required(ErrorMessage = "Informe quantos jogos foram vencidos!")]
        public int jogosVencidos { get; set; }


        //Se a quantidade de jogos vencidos for abaixo de 60% ele é pé frio
        [Display(Name="Pé Quente - Pé Frio:")]
        public string peQuenteFrio { get; set; }
    }
}