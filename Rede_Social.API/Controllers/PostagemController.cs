using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_Social.Infra.Interfaces;
using Rede_Social.Infra.Repositories;
using RedeSocial.Application.Services;
using RedeSocial.Domain;

namespace Rede_Social.API.Controllers
{
    public class PostagemController : Controller
    {
        

        private readonly IPostagemRepository _repository;
        private readonly PostagemService _postagemService;
        public PostagemController(PostagemService postagemService, IPostagemRepository repository)
        {
            _repository = repository;
            _postagemService = postagemService; // A correção está aqui
        }


        // GET: api/Users

        [HttpGet]
        [Route("Postagem")] // Adiciona uma rota específica
        public ActionResult<List<Postagem>> GetPedidos()
        {
            return _repository.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<Postagem> GetPostagemById(int id)
        {
            var postagem = _repository.GetPostagemById(id);
            if (postagem == null)
            {
                return NotFound();
            }
            return postagem;
        }

        // POST: api/Users
        [HttpPost]
        [Route("Postagem")]
        public IActionResult PostPostagem([FromBody] Postagem postagem)
        {
            if (postagem == null)
                return BadRequest("Postagem inválida."); // Validação de entrada

            var sucesso = _repository.PostPostagem(postagem);
            if (sucesso)
                return CreatedAtAction(nameof(GetPostagemById), new { id = postagem.Id }, postagem); // 201 Created

            return StatusCode(500, "Erro ao salvar a postagem."); // Falha inesperada
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeletePostagemr(int id)
        {
            if (_repository.DeletePostagem(id))
                return Ok("Postagem apagado com sucesso");

            return NotFound("Id não encontrado");

        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdatePostagem(int id, [FromBody] Postagem postagem)
        {
            if (id != postagem.Id)
            {
                return BadRequest("O ID fornecido na URL não corresponde ao ID do usuário.");
            }

            var success = _repository.UpdatePostagem(postagem);

            if (!success)
            {
                return NotFound("Usuário não encontrado para atualização.");
            }

            return NoContent(); 
        }
        
        [HttpPost("{id}/curtir")]
        public IActionResult CurtirPostagem(int id)
        {
            var postagem = _repository.GetPostagemById(id);
            if (postagem == null)
            {
                return NotFound("Postagem não encontrada."); 
            }

            postagem.Curtir(); 
            var sucesso = _repository.UpdatePostagem(postagem); 

            if (!sucesso)
            {
                return StatusCode(500, "Erro ao atualizar a postagem."); 
            }

            return Ok($"Postagem {id} agora tem {postagem.Curtidas} curtidas."); 
        }





        // Endpoint para comentar em uma postagem
        [HttpPost("{id}/comentar")]
        public IActionResult ComentarPostagem(int id, [FromBody] string comentario)
        {
            if (_postagemService.ComentarPostagem(id, comentario))
            {
                return Ok(); 
            }
            return NotFound();
        }
        
    }

}

