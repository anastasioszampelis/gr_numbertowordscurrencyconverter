using NumberToWordsConverterGRLib;
using System;
using System.Collections.Generic;

namespace NumberToWordGRConverterGRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string testNumber, testmode;
            List<int> numberOfModes = Currencies.GetNumberOfModes();

            while (true)
            {
                Console.WriteLine("Δώσε έναν αριθμό: ");
                testNumber = Console.ReadLine();
                Console.WriteLine("Διάλεξε λειτουργία: ");
                Console.WriteLine("Διαθέσιμες Λειτουργίες: ");
                foreach(int numb in numberOfModes)
                {
                    Console.Write(numb + " ");
                }
                Console.WriteLine("");
                testmode = Console.ReadLine();
                string returnedWord = NumberToWordsConverterGRLib.Converter.ConvertToWords(testNumber.ToString(), testmode).Message;
                Console.WriteLine("Ολογράφως: '{0}'", returnedWord);
            }
            
        }
    }
}
