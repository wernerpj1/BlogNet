

using System.ComponentModel.DataAnnotations;


namespace back.ViewModels.UsersViews
{
    public class RegistrarViewInput
    {
        private int Id { get; set; }
        [Required(ErrorMessage ="Preencha o seu E-mail corretamente")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Preencha Sua senha corretamente (Letras maiúsculas, minúsculas, números e caracteres especiais)")]
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
    }
}