using WebApi_Livraria.Dto.Livro;
using WebApi_Livraria.Models;

namespace WebApi_Livraria.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();       
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<LivroModel>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<LivroModel>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
        Task<ResponseModel<LivroModel>> ExcluirLivro(int idLivro);
    }
}
