using Microsoft.AspNetCore.Mvc;
using Rede_Social.Infra.Interfaces;
using RedeSocial.Domain;

namespace Rede_Social.API.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _repository;

        public EventoController(IEventoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/eventos
        [HttpGet]
        public ActionResult<List<Evento>> GetEventos()
        {
            return Ok(_repository.GetAll());
        }

        // GET: api/eventos/5
        [HttpGet("{id}")]
        public ActionResult<Evento> GetEventoById(int id)
        {
            var evento = _repository.GetEventoById(id);
            if (evento == null)
            {
                return NotFound("Evento não encontrado.");
            }
            return Ok(evento);
        }

        // POST: api/eventos
        [HttpPost]
        public IActionResult PostEvento([FromBody] Evento evento)
        {
            if (evento == null)
            {
                return BadRequest("Evento inválido."); // Validação de entrada
            }

            // Lógica: verifica se o evento é aberto ou exige inscrição
            if (evento.InscricaoObrigatoria)
            {
                Console.WriteLine("Evento exige inscrição.");
            }
            else
            {
                Console.WriteLine("Evento é aberto para todos.");
            }

            var sucesso = _repository.PostEvento(evento);
            if (sucesso)
            {
                return CreatedAtAction(nameof(GetEventoById), new { id = evento.Id }, evento); // 201 Created
            }

            return StatusCode(500, "Erro ao salvar o evento."); // Falha inesperada
        }

        // DELETE: api/eventos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(int id)
        {
            var sucesso = _repository.DeleteEvento(id);
            if (sucesso)
            {
                return Ok("Evento apagado com sucesso.");
            }

            return NotFound("Evento não encontrado.");
        }

        // PUT: api/eventos/5
        [HttpPut("{id}")]
        public IActionResult UpdateEvento(int id, [FromBody] Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest("O ID fornecido na URL não corresponde ao ID do evento.");
            }

            // Lógica: verifica o status do evento atualizado
            if (evento.InscricaoObrigatoria)
            {
                Console.WriteLine("Evento atualizado como exigindo inscrição.");
            }
            else
            {
                Console.WriteLine("Evento atualizado como aberto.");
            }

            var sucesso = _repository.UpdateEvento(evento);
            if (!sucesso)
            {
                return NotFound("Evento não encontrado para atualização.");
            }

            return NoContent(); // Retorna 204 indicando sucesso sem corpo de resposta
        }
    }
}