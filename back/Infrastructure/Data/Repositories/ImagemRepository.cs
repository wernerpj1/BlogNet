using back.Business.Entities;
using back.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Infrastructure.Data.Repositories
{
    public class ImagemRepository : IImagemRepository
    {
        private readonly ArtigoDbContext _contexto;

        public ImagemRepository(ArtigoDbContext contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Imagens imagens)
        {
            _contexto.Add(imagens);
        }

        public void Commit()
        {
            _contexto.SaveChanges();       }
        }
}
