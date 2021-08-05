using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blazor_Catalogo.Shared.Models
{
  public class UserInfo
    {
        [Required(ErrorMessage ="Informe o e=mail")]
        [EmailAddress (ErrorMessage ="Formatado do email invalido!")]
        public string  Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
      
    }
}
