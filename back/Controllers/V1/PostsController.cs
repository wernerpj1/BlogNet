
using back.Business.Entities;
using back.Business.Repositories;
using back.Filters;
using back.ViewModels;
using back.ViewModels.PostsViews;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IImagemRepository _imagemRepository;

        public PostsController(IArtigoRepository artigoRepository, IImagemRepository imagemRepository)
        {
            _artigoRepository = artigoRepository;
            _imagemRepository = imagemRepository;
        }
        [Authorize]
        [SwaggerResponse(statusCode: 201, description: "Sucesso", Type = typeof(ListaViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Erro na solicitação", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPost]
        [Route("cadastrarArtigo")]
        [ValidaCampoFilter]
        public async Task<IActionResult> Post(ListaViewInput listaViewInput)
        {
            Artigo artigo = new Artigo();
            Imagens imagens = new Imagens();
            artigo.Imagens.SlugImagem = listaViewInput.Imagens.SlugImagem;
            artigo.Titulo = listaViewInput.Titulo;
            artigo.SubcategoriaId = int.Parse(listaViewInput.Categoria);
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            artigo.UsuarioId = codigoUsuario;
            _imagemRepository.Adicionar(imagens);
            _imagemRepository.Commit();
            _artigoRepository.Adicionar(artigo);
            _artigoRepository.Commit();

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