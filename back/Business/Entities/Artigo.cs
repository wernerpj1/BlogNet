using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Business.Entities
{
    public class Artigos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int SubcategoriaId { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        public int ImagemId { get; set; }
        public virtual Imagens Imagens { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
