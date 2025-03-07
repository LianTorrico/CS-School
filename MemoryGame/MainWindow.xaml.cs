using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace memory
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        private int[] cards = { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
        private Button firstButton = null;
        private Button secondButton = null;
        int foundCards = 0;

        public MainWindow()
        {
            InitializeComponent();
            Shuffle(cards);
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
            Button clickedButton = sender as Button;
            int index = int.Parse(clickedButton.Name.Split('_')[1]) - 1;

            // Reveal the card
            clickedButton.Content = cards[index].ToString();

            if (firstButton == null)
            {
                // First button clicked
                firstButton = clickedButton;
            }
            else if (secondButton == null && clickedButton != firstButton)
            {
                // Second button clicked
                secondButton = clickedButton;

                // Check for a match
                if (firstButton.Content.ToString() == secondButton.Content.ToString())
                {
                    // Match found
                    firstButton.IsEnabled = false;
                    secondButton.IsEnabled = false;
                    foundCards += 2;
                    firstButton = null;
                    secondButton = null;

                    // Check for game over
                    if (foundCards == cards.Length)
                    {
                        MessageBox.Show("Hai trovato tutte le carte!");
                        this.Close();
                    }
                }
                else
                {
                    // No match, hide values after a short delay
                    DispatcherTimer hideTimer = new DispatcherTimer();
                    hideTimer.Interval = TimeSpan.FromSeconds(1);
                    hideTimer.Tick += (s, args) =>
                    {
                        firstButton.Content = "?";
                        secondButton.Content = "?";
                        firstButton = null;
                        secondButton = null;
                        hideTimer.Stop();
                    };
                    hideTimer.Start();
                }
            }
        }
    }
}