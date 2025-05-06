using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public List<Usuario> Seguidores { get; set; } = new List<Usuario>();

        // Método para adicionar seguidores
        public void Seguir(Usuario usuario)
        {
            if (usuario != null && !Seguidores.Contains(usuario))
            {
                Seguidores.Add(usuario);
            }
        }
    }
}