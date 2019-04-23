using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira um email para continuar.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma senha para continuar.")]
        public string Senha { get; set; }
    }
}
