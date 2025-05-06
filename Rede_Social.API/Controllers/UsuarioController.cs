using Microsoft.AspNetCore.Mvc;
using RedeSocial.Domain;
using Rede_Social.Infra.Repositories;
using Rede_Social.Infra;
using Rede_Social.Infra.Interfaces;
using RedeSocial.Application.Services;
[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{ /*
    private readonly IUsuarioRepository _repository;
    private readonly UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService, IUsuarioRepository repository)
    {
        _repository = repository;
        _usuarioService = usuarioService;
    }

    // GET: api/Users
    [HttpGet]
    public ActionResult<List<Usuario>> GetUsers()
    {
        var users = _repository.GetAll();
        return Ok(users);
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public ActionResult<Usuario> GetUserById(int id)
    {
        var user = _repository.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    // POST: api/Users
    [HttpPost]
    public ActionResult<Usuario> PostUser([FromBody] Usuario user)
    {
        if (user == null)
            return BadRequest("Dados inválidos!");

        // Inicializa a lista de seguidores como vazia, caso seja null
        if (user.Seguidores == null)
            user.Seguidores = new List<Usuario>();

        _repository.PostUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        if (_repository.DeleteUser(id))
            return Ok("Usuário apagado com sucesso");

        return NotFound("Id não encontrado");
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] Usuario user)
    {
        if (id != user.Id)
        {
            return BadRequest("O ID fornecido na URL não corresponde ao ID do usuário.");
        }

        var success = _repository.UpdateUser(user);

        if (!success)
        {
            return NotFound("Usuário não encontrado para atualização.");
        }

        return NoContent();
    }

    // POST: api/Users/{usuarioId}/seguir/{seguidorId}
    [HttpPost("{usuarioId}/seguir/{seguidorId}")]
    public ActionResult SeguirUsuario(int usuarioId, int seguidorId)
    {
        if (!_usuarioService.SeguirUsuario(usuarioId, seguidorId))
            return BadRequest("Erro ao seguir usuário");
        return NoContent();
    } */
}
