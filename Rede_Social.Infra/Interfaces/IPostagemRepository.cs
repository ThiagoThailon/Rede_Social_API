using RedeSocial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rede_Social.Infra.Interfaces
{
    public interface IPostagemRepository
    {
       

            List<Postagem> GetAll();
            Postagem GetPostagemById(int id);
            bool PostPostagem(Postagem postagem);
            bool DeletePostagem(int id);
            bool UpdatePostagem(Postagem postagem);


    }
}



