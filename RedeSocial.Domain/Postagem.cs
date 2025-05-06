using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Domain
{

    public class Postagem
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataHora { get; set; }
       // public List<int> Curtidas { get; set; }  =new List<int>();
        public List<string> Comentarios { get; set; }=   new List<string>();


        public int Curtidas { get; private set; } // Contador de curtidas


        // Incrementa o número de curtidas
        public void Curtir()
        {
            Curtidas++; // Incrementa o contador de curtidas
        }



       /* // Adiciona uma curtida
        public void AdicionarCurtida(int usuario)
        {
            Curtidas.Add(usuario);
        } */

        // Adiciona um comentário
        public void AdicionarComentario(string comentario)
        {
            Comentarios.Add(comentario);
        }
    }
}