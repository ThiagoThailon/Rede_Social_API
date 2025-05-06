using RedeSocial.Domain;
using System.Collections.Generic;

namespace Rede_Social.Infra.Interfaces
{

    public interface IUsuarioRepository
    {
      
            List<Usuario> GetAll();
            Usuario GetUserById(int id);
            bool PostUser(Usuario user);
            bool DeleteUser(int id);
            bool UpdateUser(Usuario user);
            

    }
}