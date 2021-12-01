namespace back.Business.Entities
{
    public class SubCategoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SlugSubCategoria { get; set; }
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}