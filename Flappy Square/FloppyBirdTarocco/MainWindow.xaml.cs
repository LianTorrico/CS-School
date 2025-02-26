using System.Numerics;
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

namespace FloppyBirdTarocco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private Random random = new Random();
        private int JumpValue = 10;
        private int obstacleSpeed = 5;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(450);
            timer.Tick += GameKeeper;
            timer.Start();

            this.KeyDown += MoveFloppy;
        }

        public void GameKeeper (object sender, EventArgs e)
        {
            if (random.Next(0, 10) < 2)
            {
                Rectangle obstacle = new Rectangle();
                obstacle.Width = 50;
                obstacle.Height = 130;
                obstacle.Fill = Brushes.DarkGreen;

                Canvas.SetLeft(obstacle, random.Next(600,800));
                Canvas.SetTop(obstacle, random.Next(0, 450));
                GameCanvas.Children.Add(obstacle);
            }

            for (int i = GameCanvas.Children.Count - 1; i >= 0; i--)
            {
                if (GameCanvas.Children[i] is Rectangle && GameCanvas.Children[i] != Player)
                {
                    Rectangle obstacle = (Rectangle)GameCanvas.Children[i];
                    double left = Canvas.GetLeft(obstacle);
                    Canvas.SetLeft(obstacle, left - obstacleSpeed);
                    if (left < -obstacle.Width)
                    {
                        GameCanvas.Children.Remove(obstacle);
                    }
                    if (CollisionHandler(Player, obstacle))
                    {
                        timer.Stop();
                        MessageBox.Show("Game Over!");
                        this.Close();
                    }
                }
            }


            double Top = Canvas.GetTop(Player);
            Canvas.SetTop(Player, Top + 20);
        }
        public void MoveFloppy(object sender, KeyEventArgs e) {
            double Top = Canvas.GetTop (Player);
            if (e.Key == Key.Space)
            {
                Canvas.SetTop(Player, Top - JumpValue);
            }
        }
        public bool CollisionHandler(Rectangle player, Rectangle obstacle)
        {
            double pX = Canvas.GetLeft(player);
            double pY = Canvas.GetTop(player);
            double oX = Canvas.GetLeft(obstacle);
            double oY = Canvas.GetTop(obstacle);
            return (Math.Abs(pX - oX) < player.Width) && (Math.Abs(pY - oY) < player.Height);
        }
    }
}