using Microsoft.AspNetCore.Mvc;
using WebApi_Livraria.Dto.Autor;
using WebApi_Livraria.Dto.Livro;
using WebApi_Livraria.Models;
using WebApi_Livraria.Services.Autor;
using WebApi_Livraria.Services.Livro;

namespace WebApi_Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<List<ResponseModel<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();

            return Ok(livros);            
        }
        
        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);

            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(idAutor);

            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var autor = await _livroInterface.CriarLivro(livroCriacaoDto);

            return Ok(autor);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livro = await _livroInterface.EditarLivro(livroEdicaoDto);

            return Ok(livro);
        }

        [HttpDelete("ExcluirLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ExcluirLivro(int idLivro)
        {
            var autor = await _livroInterface.ExcluirLivro(idLivro);

            return Ok(autor);
        }
    }
}
