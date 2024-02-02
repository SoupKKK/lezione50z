
namespace lezione50z
{
    class Contribuente
    {
        public string Nome;
        public string Cognome;
        public DateTime DataNascita;
        public string CodiceFiscale;
        public char Sesso;
        public string ComuneResidenza;
        public double RedditoAnnuale;

        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        public void CalcolaImposta()
        {
            double imposta = 0;

            if (RedditoAnnuale <= 15000)
            {
                imposta = RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale <= 28000)
            {
                imposta = 3450 + (RedditoAnnuale - 15000) * 0.27;
            }
            else if (RedditoAnnuale <= 55000)
            {
                imposta = 6960 + (RedditoAnnuale - 28000) * 0.38;
            }
            else if (RedditoAnnuale <= 75000)
            {
                imposta = 17220 + (RedditoAnnuale - 55000) * 0.41;
            }
            else
            {
                imposta = 25420 + (RedditoAnnuale - 75000) * 0.43;
            }

            Console.WriteLine("==================================================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine($"Contribuente: {Nome} {Cognome},");
            Console.WriteLine($"nato il {DataNascita:dd/MM/yyyy} ({Sesso}),");
            Console.WriteLine($"residente in {ComuneResidenza},");
            Console.WriteLine($"codice fiscale: {CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale:F2} euro");
            Console.WriteLine($"IMPOSTA DA VERSARE: {imposta:F2} euro");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Inserisci il nome: ");
            string nome = Console.ReadLine();

            Console.Write("Inserisci il cognome: ");
            string cognome = Console.ReadLine();

            DateTime dataNascita;
            while (true)
            {
                Console.Write("Inserisci la data di nascita (formato dd/MM/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascita))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Formato data non valido. Riprova.");
                }
            }

            Console.Write("Inserisci il codice fiscale: ");
            string codiceFiscale = Console.ReadLine();

            char sesso;
            while (true)
            {
                Console.Write("Inserisci il sesso (M/F): ");
                if (char.TryParse(Console.ReadLine().ToUpper(), out sesso) && (sesso == 'M' || sesso == 'F'))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Sesso non valido. Riprova.");
                }
            }

            Console.Write("Inserisci il comune di residenza: ");
            string comuneResidenza = Console.ReadLine();

            double redditoAnnuale;
            while (true)
            {
                Console.Write("Inserisci il reddito annuale: ");
                if (double.TryParse(Console.ReadLine(), out redditoAnnuale))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Importo non valido. Riprova.");
                }
            }

            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

            contribuente.CalcolaImposta();
        }
    }
}
