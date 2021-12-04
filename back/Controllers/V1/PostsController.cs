
using back.Business.Entities;
using back.Business.Repositories;
using back.Filters;
using back.ViewModels;
using back.ViewModels.PostsViews;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace back.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IArtigoRepository _artigoRepository;

        public PostsController(IArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso", Type = typeof(ListaViewOutput))]
        [SwaggerResponse(statusCode: 400, description: "Erro na solicitação", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPost]
        [Route("cadastrarArtigo")]
        [ValidaCampoFilter]
        public async Task<IActionResult> Post(ListaViewInput listaViewInput)
        {
            Artigo artigo = new Artigo();
            Imagens imagens = new Imagens();
            artigo.Titulo = listaViewInput.Titulo;
            imagens.SlugImagem = listaViewInput.Imagens;
            var categoria = 
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", listaViewInput);
        }


        [SwaggerResponse(statusCode: 200, description: "Sucesso", Type = typeof(ListaViewOutput))]
        [SwaggerResponse(statusCode: 400, description: "Erro na solicitação", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpGet]
        [Route("listar")]
        [ValidaCampoFilter]
        public async Task<IActionResult> Get()
        {
            var posts = new List<ListaViewOutput>();
            return Ok();
        }
    }
}