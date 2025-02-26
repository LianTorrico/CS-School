using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComparaMetodiSort
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long[] times = new long[3];


        public MainWindow()
        {
            InitializeComponent();
        }

        private int[] ArrayHandler()
        {
        int[] arrayModel = new int[200];
        Random random = new Random();
        for (int i = 0; i < arrayModel.Length; i++)
            {
                arrayModel[i] = random.Next(1000000);
            }
        return arrayModel;
        }
        public static int[] Copy(int[] array)
        {
            int[] newArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private void Sort_Bubble(int[] array)
        {
            int[] newArray = Copy(array);
            for (int i = 0; i < newArray.Length; i++)
            {
                for (int j = 0; j < newArray.Length - 1; j++)
                {
                    if (newArray[i] == newArray[j])
                    {
                        Swap(array, i, j + 1);
                    }
                }
            }
        }

        private int[] Sort_Stupid(int[] array)
        {
            int[] result = new int[array.Length]; //Final array
            int[] temparray = (int[])array.Clone(); //middle array, used to swap the numbers
            bool[] usedCycle = new bool[array.Length]; //support for the middle array
            

            for (int i = 0; i < array.Length; i++)
            {
                
                int minValue = int.MaxValue;
                int minIndex= 0;

                 for (int j=0; j < array.Length; j++)
                {
                    if (!usedCycle[j] && array[j] < minValue)
                    {
                        minValue = array[j];
                        minIndex = j;
                    }
                }
                usedCycle[minIndex] = true;
                result[i] = minValue;
            }
            return result;

        }
        private void All3_Click(object sender, RoutedEventArgs e)
        {
            // Create the variable for the average elapsed time
            decimal averageBubble = 0;

            // Create the random
            Random random = new Random();

            // Create the Stopwatch
            Stopwatch sw_Bubble = Stopwatch.StartNew();

            for (int i = 0; i <= 1000; i++)
            {

                // Measure the exection time of Sort_Bubble
                sw_Bubble.Start();
                Sort_Bubble(ArrayHandler());
                sw_Bubble.Stop();

                decimal timeOfOneIteration = sw_Bubble.ElapsedMilliseconds;
                averageBubble += timeOfOneIteration;
            }

            averageBubble /= 1000;
            MessageBox.Show("The average execution time for Sort_Bubble is: " + averageBubble + " millisecond.");

            // -- Stupid --


            // Create the variable for the average elapsed time
            decimal averageStupid = 0;

            // Create the Stopwatch
            Stopwatch sw_Stupid = Stopwatch.StartNew();

            for (int i = 0; i <= 1000; i++)
            {
                // Measure the exection time of Sort_Bubble
                sw_Stupid.Start();
                Sort_Stupid(ArrayHandler());
                sw_Stupid.Stop();

                long timeOfOneIteration = sw_Stupid.ElapsedMilliseconds;
                averageStupid += timeOfOneIteration;
            }

            averageStupid /= 1000;
            MessageBox.Show("The average execution time for Sort_Stupid is: " + averageStupid + " millisecond.");

            // -- Sort --
            decimal averageSort = 0;

            Stopwatch sw_Sort = Stopwatch.StartNew();

            for (int i = 0; i <= 1000; i++)
            {
                sw_Sort.Start();
                Array.Sort(ArrayHandler());
                sw_Sort.Stop();

                long timeOfOneIteration = sw_Sort.ElapsedMilliseconds;
                averageSort += timeOfOneIteration;

            }
            averageSort /= 1000;
            MessageBox.Show("The average execution time for Sort_Sort is: " + averageSort + " millisecond.");

            // Compare the 2 methods

            decimal betterBubble = averageBubble / 1000;
            decimal betterStupid = averageStupid / 1000;
            decimal betterSort =  averageSort / 1000;
            if (betterBubble < betterStupid)
            {
                MessageBox.Show($"Sort_Buble is {betterBubble} times better than Sort_Stupid");
            }
            else if (betterStupid < betterBubble && betterStupid < betterSort)
            {
                MessageBox.Show($"Sort_Stupid is {betterStupid} times better than Sort_Bubble");
            }
            else if (betterSort < betterBubble && betterSort < betterStupid)
            {
                MessageBox.Show($"Sort_Sort is {betterSort} times better than Sort_Sort");
            }
        }

    }
}
