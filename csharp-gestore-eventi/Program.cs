using System.Security.Cryptography.X509Certificates;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgrammaEventi programma = null;
            while (programma == null)
            {
                try
                {
                    Console.WriteLine("Inserisci il nome del tuo programma Eventi:");
                    string nomeProgramma = Console.ReadLine();
                    int numeroEventi;

                    Console.WriteLine("Indica il numero di eventi da inserire:");
                    string inputUtente = Console.ReadLine();
                    bool conversione = int.TryParse(inputUtente, out numeroEventi);
                    if (!conversione || numeroEventi <= 0)
                    {
                        throw new ArgumentException("Il numero di eventi deve essere un numero intero maggiore di zero.");
                    }

                    programma = new ProgrammaEventi(nomeProgramma);
                    for (var i = 0; i < numeroEventi; i++)
                    {
                        try
                        {
                            Console.WriteLine($"Inserisci il nome del {i + 1}° evento:");
                            string nomeEvento = Console.ReadLine();

                            Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy):");
                            DateTime dataEvento = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("Inserisci il numero di posti totali:");
                            int numeroPostiEvento = Convert.ToInt32(Console.ReadLine());

                            Evento evento = new Evento(nomeEvento, dataEvento, numeroPostiEvento);

                            Console.WriteLine("Quanti posti desideri prenotare?");
                            int numeroPrenotazioni = Convert.ToInt32(Console.ReadLine());

                            evento.PrenotaPosti(numeroPrenotazioni);
                            Console.WriteLine($"Numero posti prenotati = {evento.PostiPrenotati}");
                            Console.WriteLine($"Numero posti disponibili = {evento.CapienzaMassima - evento.PostiPrenotati}");

                            bool a = true;
                            while (a || evento.PostiPrenotati == 0)
                            {
                                Console.WriteLine("Vuoi disdire dei posti (si/no)?");
                                string risposta = Console.ReadLine();
                                if (risposta == "si")
                                {
                                    Console.WriteLine("Indica il numero di posti da disdire:");
                                    int postiDaDisdire = Convert.ToInt32(Console.ReadLine());
                                    evento.DisdiciPosti(postiDaDisdire);
                                    Console.WriteLine($"Numero posti prenotati = {evento.PostiPrenotati}");
                                    Console.WriteLine($"Numero posti disponibili = {evento.CapienzaMassima - evento.PostiPrenotati}");
                                }
                                else if (risposta == "no")
                                    a = false;
                                else
                                    break;

                            }
                            programma.Eventi.Add(evento);
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
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Errore: {e.Message}");
                }
            }
            Console.WriteLine($"Il numero di eventi nel programma è {programma.Eventi.Count()}");
            Console.WriteLine("Ecco il tuo programma eventi:");
            Console.WriteLine(programma.ToString());
            
            bool dataValida = false;
            while (!dataValida)
            {
                try
                {
                    Console.WriteLine("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy):");
                    string userInput = Console.ReadLine();
                    DateTime dataParsed;
                    if (DateTime.TryParse(userInput, out dataParsed))                    
                        dataValida = true;                  
                    else                   
                        throw new ArgumentException("Il formato della data non è corretto, riprovare rispettando il formato (gg/mm/yyyy).");                  

                    if (DateTime.Today > dataParsed)                   
                        throw new Exception("La data inserita è gia' passata, riprovare.");

                    List<Evento> eventiInData = programma.EventoPerData(dataParsed);
                    Console.WriteLine(eventiInData);
                    //programma.StringhificatoreDiListe(eventiInData);

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            //programma.SvuotaEventi();
            Console.WriteLine("Aggiungiamo anche una conferenza");
            Console.WriteLine("Inserisci ora il nome della conferenza:");
            string nomeConferenza = Console.ReadLine();
            Console.WriteLine("Inserisci ora la data della conferenza: (gg/mm/yyyy)");
            DateTime dataConferenza = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Inserisci ora il numero di posti della conferenza:");
            int postiConferenza = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci ora il nome del relatore della conferenza:");
            string nomeRelatore = Console.ReadLine();
            Console.WriteLine("Inserisci ora il costo del biglietto della conferenza");
            double prezzoConferenza = Convert.ToDouble(Console.ReadLine());

            Conferenza conferenza = new Conferenza(nomeConferenza, dataConferenza, postiConferenza, nomeRelatore, prezzoConferenza);


        }
    }
}
