using back.ViewModels.UsersViews;

namespace back.Configurations
{
    public interface IAuthenticationService
    {
        object GerarToken(UsuarioViewOutput usuarioViewModelOutput);
    }
}
