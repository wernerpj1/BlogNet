using back.ViewModels.ImagensView;

namespace back.ViewModels.PostsViews
{
    public class ListaViewInput
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; } 
        public string Categoria { get; set; }
        public ImagensViewInput Imagens { get; set; }
        
    }
}