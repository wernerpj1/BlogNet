using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.ViewModels.UsersViews
{
    public class UsuarioViewOutput
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}