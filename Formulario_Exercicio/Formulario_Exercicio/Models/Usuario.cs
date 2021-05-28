using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Formulario_Exercicio.Models
{
    public class Usuario
    {
        #region eu que fiz
        //[Required(ErrorMessage = "O nome deve ser informado")]
        //[StringLength(10, ErrorMessage = "O nome não pode exceder 10 caracteres")]
        //public string Nome { get; set; }

        //[Required(ErrorMessage = "O sobrenome deve ser informado")]
        //[StringLength(10, ErrorMessage = "O sobrenome não pode exceder 10 caracteres")]
        //public string Sobrenome { get; set; }

        //[Required(ErrorMessage = "A idade deve ser informada")]
        //[Range(18, 100, ErrorMessage = "A idade deve estar entre 18 e 100")]
        //public int Idade { get; set; }
        //[Required(ErrorMessage = "O login deve ser informado")]
        //[StringLength(10, MinimumLength=4, ErrorMessage = "O mínimo 4 caracteres")]
        //public string Login { get; set; }
        //[Required(ErrorMessage = "O e-mail deve ser informado")]
        //[EmailAddress(ErrorMessage = "E-mail é invalido")]
        //public string Email { get; set; }
        //[Required(ErrorMessage = "O perfil deve ser informado")]
        //public string Perfil { get; set; }
        //[Required(ErrorMessage = "A senha deve ser informada")]
        //[StringLength(8, ErrorMessage = "A senha não pode exceder 8 caracteres")]
        //public string Password { get; set; } = string.Empty;

        //[Required(ErrorMessage = "A senha deve ser informada")]
        //[StringLength(8, ErrorMessage = "A senha não pode exceder 8 caracteres")]
        //public string ConfirmaPassword { get; set; } = string.Empty;
        #endregion
        [Required(ErrorMessage = "O primeiro nome é obrigatório.")]
        [StringLength(10, ErrorMessage = "O primeiro nome é muito longo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [StringLength(10, ErrorMessage = "O sobrenome é muito longo.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A idade é obrigatória.")]
        [Range(18, 100, ErrorMessage = "A idade deve ser maior que 18")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [MinLength(4, ErrorMessage = "O nome do usuário deve ter no mínimo 4 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato do email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O perfil do usuário é obrigatório")]
        public string Perfil { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "A confirmação da senha é obrigatória.")]
        [Compare(nameof(Password), ErrorMessage = "A senha não confere")]
        public string ConfirmaPassword { get; set; } = string.Empty;
    }
}
