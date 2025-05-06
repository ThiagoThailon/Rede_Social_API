using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public bool InscricaoObrigatoria { get; set; } // Indica se o evento exige inscrição

        // Método para verificar o tipo de evento
        public string TipoEvento()
        {
            return InscricaoObrigatoria ? "Evento exige inscrição." : "Evento aberto para todos.";
        }
    }



}


