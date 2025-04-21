using Microsoft.EntityFrameworkCore;
using WebApi_Livraria.Data;
using WebApi_Livraria.Dto.Livro;
using WebApi_Livraria.Models;

namespace WebApi_Livraria.Services.Livro
{
    public class LivroServices : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {

                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro Localizado";

                return resposta;

            }
            catch (Exception e)
            {

                resposta.Mensagem = e.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livros localizados";

                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autoBanco => autoBanco.Id == livroCriacaoDto.IdAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro do autor localizado!";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor
                };


                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = livro;
                resposta.Mensagem = "Livro criado com sucesso!";

                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEdicaoDto.Id);

                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEdicaoDto.Autor.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado";
                    return resposta;
                }

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado";
                    return resposta;
                }

                livro.Titulo = livroEdicaoDto.Titulo;
              
                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = livro;
                resposta.Mensagem = "Livro editado com sucesso!";

                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> ExcluirLivro(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = livro;
                resposta.Mensagem = "Livro removido com sucesso!";

                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.Include(autorLivro => autorLivro.Autor).ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram coletados";

                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }       
    }
}
