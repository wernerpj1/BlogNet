using back.ViewModels.ImagensView;

namespace back.ViewModels.PostsViews
{
    public class ListaViewInput
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; } 
<<<<<<< HEAD
        public string Categoria { get; set; }
        public ImagensViewInput Imagens { get; set; }
=======
        public SubCategoria SubCategoriaId { get; set; }
        public Imagens ImagensId { get; set; }
        public Usuario UsuarioId { get; set; }
>>>>>>> fb8ca20cdb9b75abd76f6a7034d5299a6d2ddc77
        
    }
}