
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

        [Authorize]
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
         //  var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
         //  var symmetricSecurityKey = new SymmetricSecurityKey(secret); 
         //  var securityTokenDescriptor = new SecurityTokenDescriptor
         //  {
         //      Subject = new ClaimsIdentity(new Claim[]
         //      {
         //          new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Id.ToString()),
         //          new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
         //      }),
         //      Expires = DateTime.UtcNow.AddDays(1),
         //      SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
         //  };
         //  var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
         //  var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
         //  var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

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
          //  var optionsBuilder = new DbContextOptionsBuilder<ArtigoDbContext>();
          //  optionsBuilder.UseSqlServer("Server=desktop-2dvh51e\\sqlexpress; Database= Blog; user= riddle; password = Deusminhavida2403");
          //  ArtigoDbContext contexto = new ArtigoDbContext(optionsBuilder.Options);

          //  var pendentMigrations = contexto.Database.GetPendingMigrations();
          //  if (pendentMigrations.Count() > 0)
          //  {
          //      contexto.Database.Migrate();
          //  }

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