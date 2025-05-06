using Microsoft.EntityFrameworkCore;
using Rede_Social.Infra.Interfaces;
using RedeSocial.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Rede_Social.Infra.Repositories
{
    public class UsuarioRepositorie : IUsuarioRepository
    {
        private readonly SqlContext _usersContext;

        public UsuarioRepositorie()
        {

            _usersContext = new SqlContext();
        }


        public List<Usuario> GetAll()
        {
           return _usersContext.Usuarios.ToList(); // Obtém todos os usuários
            
        }


        public Usuario GetUserById(int id)
        {
          
          return _usersContext.Usuarios.Find(id);
          
     
        }

        public bool PostUser(Usuario user)
        {
            if (user == null) return false;
            _usersContext.Usuarios.Add(user);
            _usersContext.SaveChanges();
            return true;

        }

        public bool DeleteUser(int id)
        {
            if (id == 0) return false;
            var user = _usersContext.Usuarios.Find(id);
            _usersContext.Usuarios.Remove(user); // Remove o usuário da lista
            _usersContext.SaveChanges();
            return true;
        }

         public bool UpdateUser(Usuario user)
         {
             var existingUser = GetUserById(user.Id);
             if (existingUser == null) return false;

             // Atualiza os dados do usuário
             existingUser.Nome = user.Nome;
             existingUser.Email = user.Email;
             _usersContext.Update(existingUser);
             _usersContext.SaveChanges();

             return true;
         }
       
      


    }
}
