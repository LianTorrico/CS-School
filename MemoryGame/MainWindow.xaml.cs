using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        private int[] cards = {1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8};
        public MainWindow()
        {
            InitializeComponent();
            Shuffle<Int32>(cards);
            timer = new DispatcherTimer();
            timer.Start();

        }
        private void GameConf()
        {

        }
        private static void Shuffle<T>(T[] array)
        {
            Random random = new Random();
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length - 1; ++i)
            {
                int r = random.Next(i, array.Length);
                (array[r], array[i]) = (array[i], array[r]);
            }
        }

        private void BTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}