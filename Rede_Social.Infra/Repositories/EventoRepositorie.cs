using Rede_Social.Infra.Interfaces;
using RedeSocial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rede_Social.Infra.Repositories
{
    public class EventoRepositorie : IEventoRepository
    {
        private readonly SqlContext _evento;

        public EventoRepositorie()
        {
            _evento = new SqlContext();
        }

        // Obtém todos os eventos
        public List<Evento> GetAll()
        {
            return _evento.Eventos.ToList();
        }

        // Obtém um evento pelo ID
        public Evento GetEventoById(int id)
        {
            return _evento.Eventos.Find(id);
        }

        // Adiciona um novo evento
        public bool PostEvento(Evento evento)
        {
            if (evento == null) return false;

            // Regras de Negócio: Validação do evento
            if (evento.InscricaoObrigatoria)
            {
                Console.WriteLine("Evento exige inscrição.");
            }
            else
            {
                Console.WriteLine("Evento aberto para todos.");
            }

            _evento.Eventos.Add(evento);
            _evento.SaveChanges();
            return true;
        }

        // Deleta um evento
        public bool DeleteEvento(int id)
        {
            var evento = GetEventoById(id);
            if (evento == null)
                return false;

            _evento.Remove(evento);
            _evento.SaveChanges();
            return true;
        }

        // Atualiza um evento existente
        public bool UpdateEvento(Evento evento)
        {
            var eventoExistente = GetEventoById(evento.Id);
            if (eventoExistente == null)
                return false;

            // Atualiza os dados do evento
            eventoExistente.Nome = evento.Nome;
            eventoExistente.Local = evento.Local;
            eventoExistente.Descricao = evento.Descricao;
            eventoExistente.DataHora = evento.DataHora;
            eventoExistente.InscricaoObrigatoria = evento.InscricaoObrigatoria; // Atualiza se exige inscrição

            // Regras de Negócio: Validação durante a atualização
            if (evento.InscricaoObrigatoria)
            {
                Console.WriteLine("Evento atualizado como exigindo inscrição.");
            }
            else
            {
                Console.WriteLine("Evento atualizado como aberto.");
            }

            _evento.SaveChanges();
            return true;
        }
    }
}