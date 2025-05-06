using Rede_Social.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Rede_Social.Infra.Interfaces;
using RedeSocial.Domain;
namespace RedeSocial.Application.Services
{

    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Método que adiciona um seguidor à lista de seguidores do usuário
        public bool SeguirUsuario(int usuarioId, int seguidorId)
        {
            var usuario = _usuarioRepository.GetUserById(usuarioId);
            var seguidor = _usuarioRepository.GetUserById(seguidorId);

            if (usuario == null || seguidor == null)
                return false;

            // Chama o método Seguir para adicionar o seguidor
            usuario.Seguir(seguidor);

            // Atualiza o usuário no banco de dados
            return _usuarioRepository.UpdateUser(usuario);
        }
    }
}