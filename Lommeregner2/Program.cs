using System;
using LommeregnerBibliotek;

namespace Lommeregner2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bool der viser om lommeregneren kører
            bool appAktiv = true;

            //Opret en lommeregner klasse
            Lommeregner lommeregner = new Lommeregner();

            while (appAktiv)
            {
                //Variabler der bruges til beregning
                string input1 = "";
                string input2 = "";
                double result = 0;

                //Spørg bruger efter det første tal
                Console.WriteLine("Indtast det første tal og tryk på enter");
                input1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(input1, out cleanNum1))
                {
                    Console.WriteLine("Ikke gyldigt input, venligst indtast et tal!");
                    input1 = Console.ReadLine();
                }

                //Spørg bruger efter det andet tal
                Console.WriteLine("Indtast det andet tal og tryk på enter");
                input2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(input2, out cleanNum2))
                {
                    Console.WriteLine("Ikke gyldigt input, venligst indtast et tal!");
                    input1 = Console.ReadLine();
                }

                //Spørg brugeren efter en operator!
                Console.WriteLine("Vælg en operator fra listen:");
                Console.WriteLine("\tp - Plus");
                Console.WriteLine("\tm - Minus");
                Console.WriteLine("\tg - Gange");
                Console.WriteLine("\td - Dividere");
                Console.Write("Dit Valg? ");

                string op = Console.ReadLine();
                try
                {
                    result = lommeregner.LavBeregning(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Denne operation vil føre til en matematisk fejl!\n");
                    }
                    else
                    {
                        //{0:0.##} sætter to tegn efter decimalet
                        Console.WriteLine("Resultatet er: {0:0.##}\n", result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Åh nej! Der skete en fejl\n - Fejlkode: " + e.Message);
                }
                Console.WriteLine("------------------------\n");
                Console.WriteLine("Tryk på 'e' også enter for at afslutte lommeregneren...\n" +
                "Tryk på en anden knap end 'e' også enter for at genstarte lommeregneren...");
                if (Console.ReadLine() == "e")
                {
                    appAktiv = false;
                }
            }
            //Skriver det sidste til JSON objektet(end array og end object og lukker writeren)
            lommeregner.Finish();
            return;
        }
    }
}
