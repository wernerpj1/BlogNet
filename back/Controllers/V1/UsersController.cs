
using back.Business.Entities;
using back.Business.Repositories;
using back.Configurations;
using back.Filters;
using back.ViewModels;
using back.ViewModels.UsersViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace back.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class Users : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthenticationService _authentication;

        public Users(IUsuarioRepository usuarioRepository,
                     IAuthenticationService authentication)
        {
            _usuarioRepository = usuarioRepository;
            _authentication = authentication;
        }

       [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewOutput))]
       [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
       [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
       [HttpPost]
       [Route("login")]
       [ValidaCampoFilter]
       public IActionResult Logar(LoginViewInput loginViewInput)
       {
            var usuario = _usuarioRepository.ObterUsuario(loginViewInput.Email); 
            

            if(usuario == null)
            {
                return BadRequest("Erro ao tentar acessar");
            }
            
            var usuarioViewModelOutput = new UsuarioViewOutput()
            {
                Id = usuario.Id,
                Email = usuario.Email,
            };

            var token = _authentication.GerarToken(usuarioViewModelOutput);

            return Ok(new {
               Token = token,
               Usuario = usuarioViewModelOutput
           });
       } 
       [SwaggerResponse(statusCode: 201, description: "Sucesso ao autenticar", Type = typeof(LoginViewOutput))]
       [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
       [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
       [HttpPost]
       [Route("registrar")]
       [ValidaCampoFilter]
       public IActionResult Registrar(RegistrarViewInput registrarViewInput)
       {
            var usuario = new Usuario();

            usuario.Email = registrarViewInput.Email;
            usuario.Senha = registrarViewInput.Senha;
            usuario.Active = false;
            usuario.Excluido = false;
            
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();


           return Created("", registrarViewInput);
       } 
    }
}