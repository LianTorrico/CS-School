using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calcolatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_________        .__               .__          __         .__              ");
            Console.WriteLine("\\_   ___ \\_____  |  |   ____  ____ |  | _____ _/  |________|__| ____  ____  ");
            Console.WriteLine("/    \\  \\/\\__  \\ |  | _/ ___\\/  _ \\|  | \\__  \\\\   __\\_  __ \\  |/ ___\\/ __ \\ ");
            Console.WriteLine("\\     \\____/ __ \\|  |_\\  \\__(  <_> )  |__/ __ \\|  |  |  | \\/  \\  \\__\\  ___/ ");
            Console.WriteLine(" \\______  (____  /____/\\___  >____/|____(____  /__|  |__|  |__|\\___  >___  >");
            Console.WriteLine("        \\/     \\/          \\/                \\/                    \\/    \\/ ");
            /*-----Variabili-----*/
            char choice;
            int a, b;
            int sum=0;
            /*-----Input-----*/
            Console.WriteLine("Inserire il primo numero:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Specificare il tipo di operazione [+,-,/,*]");
            choice = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Inserire il secondo numero:");
            b = Convert.ToInt32(Console.ReadLine());
            /*-----Calcolo-----*/
            if (choice == '+')
            {
                sum = a + b;
            }
            else if (choice == '-')
            {
                sum = a - b;
            }
            else if (choice == '/') {
            sum = a / b;
            }
            else if (choice == '*') { sum = a * b; }
            /*-----Output-----*/
            Console.WriteLine("il risultato di "+a+choice+b+" è: "+sum);
        }
    }
}
