using Rede_Social.Infra.Interfaces;
using RedeSocial.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rede_Social.Infra.Repositories
{
    public class PostagemRepositorie : IPostagemRepository
    {
        private readonly SqlContext _postagem;

        public PostagemRepositorie()
        {

            _postagem = new SqlContext();
        }


        public List<Postagem> GetAll()
        {
            return _postagem.Postages.ToList(); // Obtém todos os usuários

        }


        public Postagem GetPostagemById(int id)
        {

            return  _postagem.Postages .Find(id);
          

        }

        public bool PostPostagem(Postagem postagem)
        {
            if (postagem == null) return false;
            _postagem.Postages .Add(postagem);
            _postagem.SaveChanges();
            return true;

        }

        public bool DeletePostagem(int id)
        {
            var postagem = GetPostagemById(id);
            if (postagem == null)
                return false;
            _postagem.Remove(postagem);
            _postagem.SaveChanges();
            return true;


        }

        public bool UpdatePostagem(Postagem postagem)
        {
            var postagemExistente = GetPostagemById(postagem.Id);
            if (postagemExistente == null)
                return false;

            postagemExistente.Autor = postagem.Autor;
            postagemExistente.Conteudo = postagem.Conteudo;
            postagemExistente.DataHora = postagem.DataHora;
            _postagem.SaveChanges();
            return true;


            
        }




    }
}