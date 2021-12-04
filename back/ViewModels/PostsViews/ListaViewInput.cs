namespace back.ViewModels.PostsViews
{
    public class ListaViewInput
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; } 
        public SubCategoria SubCategoriaId { get; set; }
        public Imagens ImagensId { get; set; }
        public Usuario UsuarioId { get; set; }
        
    }
}