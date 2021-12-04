using back.Business.Entities;
using back.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace back.Infrastructure.Data.Repositories
{
    public class ArtigoRepository : IArtigoRepository
    {
        private readonly ArtigoDbContext _contexto;

        public ArtigoRepository(ArtigoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Artigo artigo)
        {
            _contexto.Artigo.Add(artigo);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<Artigo> ObterPorUsuario(int usuarioId)
        {
            return _contexto.Artigo.Where(w => w.UsuarioId == usuarioId).ToList();
        }
    }
}
