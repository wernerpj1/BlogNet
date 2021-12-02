using back.ViewModels.UsersViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Configurations
{
    public interface IAuthenticationService
    {
        object GerarToken(UsuarioViewOutput usuarioViewModelOutput);
    }
}
