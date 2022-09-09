using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CADASTRO_DE_CLUBE_DE_FUTEBOL.Models
{
    public class clsPessoa
    {

        public int Id { get; set; }

        [Display(Name ="Nome:*")]
        [Required (ErrorMessage = "Nome deve ser inserido!")]
        public string nome { get; set; }

        [Display(Name ="Time:*")]
        [Required (ErrorMessage = ("Time deve ser inserido!"))]
        public string time { get; set; }

        [Display(Name ="Idade:*")]
        [Required (ErrorMessage ="Idade deve ser inserida!")]
        public int idade { get; set; }

        }
    }