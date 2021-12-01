
using back.Business.Entities;
using back.Filters;
using back.Infrastructure.Data;
using back.ViewModels;
using back.ViewModels.UsersViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace back.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class Users : ControllerBase
    {
        

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewOutput))]
       [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
       [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
       [HttpPost]
       [Route("login")]
       [ValidaCampoFilter]
       public IActionResult Logar(LoginViewInput loginViewInput)
       {
           var usuarioViewModelOutput = new UsuarioViewOutput()
           {
               Id = 1,
               Email = "wernerpj@live.com",
           };
           var secret = Encoding.ASCII.GetBytes("MaisUmaSenha24@3");
           var symmetricSecurityKey = new SymmetricSecurityKey(secret); 
           var securityTokenDescriptor = new SecurityTokenDescriptor
           {
               Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Id.ToString()),
                   new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
               }),
               Expires = DateTime.UtcNow.AddDays(1),
               SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
           };
           var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
           var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
          
           var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);
           return Ok(new {
               Token = token,
               Usuario = usuarioViewModelOutput
           });
       } 

       [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewOutput))]
       [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
       [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
       [HttpPost]
       [Route("registrar")]
       [ValidaCampoFilter]
       public IActionResult Registrar(RegistrarViewInput registrarViewInput)
       {
            var optionsBuilder = new DbContextOptionsBuilder<ArtigoDbContext>();
            optionsBuilder.UseSqlServer("Server=desktop-2dvh51e\\sqlexpress; Database= Blog; user= riddle; password = Deusminhavida2403");
            ArtigoDbContext contexto = new ArtigoDbContext(optionsBuilder.Options);

            var pendentMigrations = contexto.Database.GetPendingMigrations();
            if(pendentMigrations.Count() > 0)
            {
                contexto.Database.Migrate();
            }

            var usuario = new Usuario();

            usuario.Email = registrarViewInput.Email;
            usuario.Senha = registrarViewInput.Senha;
            usuario.Active = false;
            usuario.Excluido = false;
            contexto.Usuario.Add(usuario);
            contexto.SaveChanges();
           return Created("", registrarViewInput);
       } 
    }
}