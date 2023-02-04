using Chapter.WebApi.Interfaces;
using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _ilivroRepository;

        public LivroController(ILivroRepository ilivroRepository)
        {
            _ilivroRepository = ilivroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_ilivroRepository.Ler());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livro = _ilivroRepository.BuscarPorId(id);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "7")]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _ilivroRepository.Cadastrar(livro);
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {
            try
            {
                _ilivroRepository.Atualizar(id, livro);
                return StatusCode (204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);                
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ilivroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("titulo/{titulo}")]

        public IActionResult GetByTitulo(string titulo)
        {
            try
            {
                Livro livro = _ilivroRepository.BuscarPorTitulo(titulo);
                
                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }
        }
    }
}