namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Evento test = new Evento("Concerto", new DateTime(2024, 6, 15), 100);

                test.PrenotaPosti(50);
                test.DisdiciPosti(20);
                Console.WriteLine(test.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Errore: {e.Message}");
            }
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine($"Operazione non valida: {e.Message}");
            //}
            catch (Exception e)
            {
                Console.WriteLine($"Si è verificato un errore: {e.Message}");
            }
        }
    }
}
