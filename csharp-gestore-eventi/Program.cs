using System.Security.Cryptography.X509Certificates;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Inserisci il nome dell'evento:");
                string nomeEvento = Console.ReadLine();

                Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy):");
                DateTime dataEvento = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Inserisci il numero di posti totali:");
                int numeroPostiEvento = Convert.ToInt32(Console.ReadLine());

                Evento ufficiale = new Evento(nomeEvento, dataEvento, numeroPostiEvento);

                Console.WriteLine("Quanti posti desideri prenotare?");
                int numeroPrenotazioni = Convert.ToInt32(Console.ReadLine());

                ufficiale.PrenotaPosti(numeroPrenotazioni);
                Console.WriteLine($"Numero posti prenotati = {ufficiale.PostiPrenotati}");
                Console.WriteLine($"Numero posti disponibili = {ufficiale.CapienzaMassima - ufficiale.PostiPrenotati}");

                bool a = true;
                while (a || ufficiale.PostiPrenotati == 0)
                {
                    Console.WriteLine("Vuoi disdire dei posti (si/no)?");
                    string risposta = Console.ReadLine();
                    if (risposta == "si")
                    {
                        Console.WriteLine("Indica il numero di posti da disdire:");
                        int postiDaDisdire = Convert.ToInt32(Console.ReadLine());
                        ufficiale.DisdiciPosti(postiDaDisdire);
                        Console.WriteLine($"Numero posti prenotati = {ufficiale.PostiPrenotati}");
                        Console.WriteLine($"Numero posti disponibili = {ufficiale.CapienzaMassima - ufficiale.PostiPrenotati}");
                    }
                    else if (risposta == "no")
                        a = false;
                    else
                        break;
                        
                }
                
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Errore: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Si è verificato un errore: {e.Message}");
            }
        }
    }
}
