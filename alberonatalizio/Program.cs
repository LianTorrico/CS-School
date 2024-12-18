using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alberonatalizio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height;
            bool check = false;
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci l'altezza dell'albero di Natale: ");
            while (check=false)
            {
                if (height % 2 == 0)
                {
                    Console.WriteLine("Inserire un numero dispari");

                }
                else {
                check = true;
                }
            }
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < height - i - 1; j++) {
                    Console.Write(" ");
                }
                for (int k = 0;k<(2*i+1); k++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < height / 3; i++) {
                for (int j = 0; j < height - i; j++) {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("|");
            Console.WriteLine("Buon 2025!!!");
            Console.WriteLine("Buon Natale!");
        }
    }
}
