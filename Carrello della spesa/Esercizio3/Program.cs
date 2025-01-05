using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Esercizio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*------Titolo------*/
            Console.WriteLine("  ___ _    ___                  _ _          _     _ _                              ");
            Console.WriteLine(" |_ _| |  / __|__ _ _ _ _ _ ___| | |___   __| |___| | |__ _   ____ __  ___ ___ __ _ ");
            Console.WriteLine("  | || | | (__/ _` | '_| '_/ -_) | / _ \\ / _` / -_) | / _` | (_-< '_ \\/ -_|_-</ _` |");
            Console.WriteLine(" |___|_|  \\___\\__,_|_| |_| \\___|_|_\\___/ \\__,_\\___|_|_\\__,_| /__/ .__/\\___/__/\\__,_|");
            Console.WriteLine("                                                                |_|                 ");
            /*------Variabili------*/
            double sum =0;
            int input;
            /*------Array Prodotti------*/
            Prodotto[] prodotti = new Prodotto[11];
            prodotti[0] = new Prodotto("Carlo Carota",14999.99);
            prodotti[1] = new Prodotto("Igor Miti", 3999.99);
            prodotti[2] = new Prodotto("Marco Mela", 7999.99);
            prodotti[3] = new Prodotto("Brian Banana", 9999.99);
            prodotti[4] = new Prodotto("Paolo Pizza", 5699.99);
            prodotti[5] = new Prodotto("Patrick Pomodoro", 3299.99);
            prodotti[6] = new Prodotto("Eduardo Garcia Lòpez", 260099.99);
            prodotti[7] = new Prodotto("Ylenia Yogurt", 25699.99);
            prodotti[8] = new Prodotto("Nicky Kiwi", 260099.99);
            prodotti[9] = new Prodotto("Low Taper Fade", 99999999999.99);
            prodotti[10] = new Prodotto("Sapone per le mani", 599999.99);
            /*------Ciclo------*/
            for (int i = 0; i < prodotti.Length; i++)
            {
                Console.WriteLine($"Prodotto {i} : [{prodotti[i].Name}] Prezzo: ${prodotti[i].Prezzo}");
            }
            while (true)
            {
                Console.WriteLine("Inserire il numero del prodotto da aggiungere al Carrello, inserire il numero 2025 per uscire dal programma");
                input = int.Parse(Console.ReadLine());
                if (input == 2025)
                {
                    break; //Uscita
                }
                sum += prodotti[input].Prezzo;
                Console.WriteLine("Prezzo totale attuale:" + sum);
            }
        }
        public class Prodotto{
            public string Name { get; set; }
            public double Prezzo { get; set; }
            public Prodotto(string nome, double prezzo) {
                Name = nome;
                Prezzo = prezzo;
            }

        }
    }
}