using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PariDispari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*----------Elementi----------*/
            int a;
            /*----------Input Numero----------*/
            Console.WriteLine("Inserire un numero");
            a = Convert.ToInt32(Console.ReadLine());
            /*----------Controllo numero (Pari)----------*/
            if (a % 2 == 0)
            {
                Console.WriteLine("Numero pari");
            }
            /*----------Controllo numero (Dispari)----------*/
            else
            {
                Console.WriteLine("Numero dispari");
            }
        }
    }
}
