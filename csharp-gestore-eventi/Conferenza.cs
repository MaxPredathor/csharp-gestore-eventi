using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Conferenza : Evento
    {
        public string Relatore {  get; set; }
        public double Prezzo { get; set; }
        public Conferenza(string titolo, DateTime data, int capienzaMassima, string relatore, double prezzo)
        : base(titolo, data, capienzaMassima)
        {
            Relatore = relatore;
            Prezzo = prezzo;
        }
        public string GetDataFormattata()
        {
            return Data.ToString("dd/MM/yyyy");
        }

        public string GetPrezzoFormattato()
        {
            return Prezzo.ToString("0.00") + " euro";
        }

        public override string ToString()
        {
            return $"{GetDataFormattata()} - {Titolo} - {Relatore} - {GetPrezzoFormattato()}";
        }
    }
}
