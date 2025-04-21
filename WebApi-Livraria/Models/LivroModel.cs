namespace WebApi_Livraria.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public AutorModel Autor { get; set; } = null!;
    }
}
