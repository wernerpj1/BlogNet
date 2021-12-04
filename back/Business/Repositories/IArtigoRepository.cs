using back.Business.Entities;
using System.Collections.Generic;

namespace back.Business.Repositories
{
    public interface IArtigoRepository
    {
        void Adicionar(Artigo artigo);
        void Commit();
        IList<Artigo> ObterPorUsuario(int usuarioId);
    }
}
