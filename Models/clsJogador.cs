using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CADASTRO_DE_CLUBE_DE_FUTEBOL.Models
{
    public class clsJogador : clsPessoa
    {

        [Display (Name ="Posição:*")]
        [Required (ErrorMessage="Posição deve ser inserida!")]
        public string posicao { get; set; }

        [Display (Name ="Número da camisa:*")]
        [Required (ErrorMessage="Número da camisa deve ser inserida!")]
        public int numeroCamisa { get; set; }

        [Display (Name ="Gols marcados:*")]
        [Required (ErrorMessage = "Informar quantidade de gols marcados!")]
        public int golsMarcados { get; set; }
    }
}