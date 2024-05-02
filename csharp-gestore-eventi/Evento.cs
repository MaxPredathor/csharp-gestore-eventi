using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        private string titolo;
        public string Titolo {
            get { return titolo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Il titolo non può essere vuoto");
                else
                    titolo = value;
            }
        }
        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set
            {
                if (value < DateTime.Today)
                    throw new ArgumentException("La data dell'evento non può essere nel passato.");
                data = value;
            }
        }

        private int capienzaMassima;
        public int CapienzaMassima
        {
            get { return capienzaMassima; }
        }

        private int postiPrenotati;
        public int PostiPrenotati
        {
            get { return postiPrenotati; }
        }

        public Evento(string titolo, DateTime data, int capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            if (capienzaMassima <= 0)
                throw new ArgumentException("La capienza massima deve essere un numero positivo.");
            this.capienzaMassima = capienzaMassima;
            postiPrenotati = 0;
        }

        public void PrenotaPosti(int numeroPostiDaPrenotare)
        {
            if (DateTime.Today >= data)
                throw new Exception("Impossibile prenotare posti per un evento passato.");
            if (postiPrenotati + numeroPostiDaPrenotare > capienzaMassima)
                throw new Exception("Il numero di posti da prenotare inserito eccede la capienza massima.");

            postiPrenotati += numeroPostiDaPrenotare;
        }
        public void DisdiciPosti(int numeroPostiDaDisdire)
        {
            if (DateTime.Today >= data)
                throw new Exception("Impossibile disdire posti per un evento passato.");
            if (postiPrenotati - numeroPostiDaDisdire < 0)
                throw new Exception("Non ci sono abbastanza posti prenotati da disdire.");

            postiPrenotati -= numeroPostiDaDisdire;
        }
        public override string ToString()
        {
            string dataFormattata = Data.ToString("dd/MM/yyyy");    
            return $"{dataFormattata} -- {Titolo}";
        }
    }
}
