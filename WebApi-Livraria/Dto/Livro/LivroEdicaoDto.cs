using WebApi_Livraria.Dto.Vinculo;

namespace WebApi_Livraria.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public AutorVinculoDto Autor { get; set; } = null!;
    }
}
