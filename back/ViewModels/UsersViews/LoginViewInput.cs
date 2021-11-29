using System;

using System.ComponentModel.DataAnnotations;


namespace back.ViewModels.UsersViews
{
    public class LoginViewInput
    {
        [Required(ErrorMessage ="Insira um E-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Insira uma senha válida")]
        public string Senha { get; set; }
        
    }
}