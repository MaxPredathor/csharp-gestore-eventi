using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        public string Titolo { get; set; }
        public List<Evento> Eventi { get; set; }
        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }
        public void AggiungiEvento(Evento evento)
        {
            Eventi.Add(evento);
        }
        public List<Evento> EventoPerData(DateTime data)
        {
            List<Evento> eventiInData = new List<Evento>();
            foreach(Evento evento in Eventi) 
            {
                if(evento.Data == data)
                    eventiInData.Add(evento); 
                break;
            }
            return eventiInData;
        }
        public static string StringhificatoreDiListe(List<Evento> lista)
        {
            string megaStringa = "";
            foreach (Evento evento in lista)
            {
                megaStringa += $"Titolo: {evento.Titolo}, Data: {evento.Data}, Partecipanti: {evento.PostiPrenotati}\n";
            }
            return megaStringa;
        }
        public int ControlloEventi()
        {
            return Eventi.Count;
        }
        public void SvuotaEventi()
        {
            Eventi.Clear();
        }
        public override string ToString()
        {
            string megaStringa = "Nome programma evento:\n";
            foreach (Evento evento in Eventi)
            {
               megaStringa += $"    {evento.Data} -- {evento.Titolo}\n";
            }
            return megaStringa;
        }
    }
}
