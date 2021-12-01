
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using back.Filters;
using back.ViewModels;
using back.ViewModels.UsersViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

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
           return Created("", registrarViewInput);
       } 
    }
}