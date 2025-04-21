using WebApi_Livraria.Dto.Autor;
using WebApi_Livraria.Models;

namespace WebApi_Livraria.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<AutorModel>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<AutorModel>> ExcluirAutor(int idAutor);

    }
}
