using Rede_Social.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rede_Social.Infra.Repositories
{
    public class PostagemService
    {
        private readonly IPostagemRepository _postagemRepository;

        public PostagemService(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        // Adiciona uma curtida na postagem
        /*  public bool CurtirPostagem(int postagemId, int usuario)
          {
              var postagem = _postagemRepository.GetPostagemById(postagemId);
              if (postagem == null)
              {
                  return false; // Postagem não encontrada
              }

              postagem.AdicionarCurtida(usuario); // Adiciona a curtida
              return _postagemRepository.UpdatePostagem(postagem); // Atualiza a postagem no repositório
          } */

        public bool CurtirPostagem(int postagemId, int usuarioId)
        {
            if (usuarioId <= 0) // Validação do ID do usuário
            {
                throw new ArgumentException("ID do usuário inválido.");
            }

            var postagem = _postagemRepository.GetPostagemById(postagemId);
            if (postagem == null)
            {
                return false; // Postagem não encontrada
            }

            postagem.Curtir(); // Adiciona a curtida
            return _postagemRepository.UpdatePostagem(postagem); // Atualiza a postagem no repositório
        }


        // Adiciona um comentário na postagem
        public bool ComentarPostagem(int postagemId, string comentario)
        {
            var postagem = _postagemRepository.GetPostagemById(postagemId);
            if (postagem == null)
            {
                return false; // Postagem não encontrada
            }

            postagem.AdicionarComentario(comentario); // Adiciona o comentário
            return _postagemRepository.UpdatePostagem(postagem); // Atualiza a postagem no repositório
        }
    }
}