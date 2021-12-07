using back.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Business.Repositories
{
    public interface IImagemRepository
    {
        void Adicionar(Imagens imagens);
        void Commit();
    }
}
