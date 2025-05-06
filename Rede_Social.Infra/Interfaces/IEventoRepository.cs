using RedeSocial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rede_Social.Infra.Interfaces
{

    public interface IEventoRepository
    {
        List<Evento> GetAll();
        Evento GetEventoById(int id);
        bool PostEvento(Evento evento);
        bool DeleteEvento(int id);
        bool UpdateEvento(Evento evento);



    }
}
