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

namespace CalcolatriceCreativa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string equation = "";
        public MainWindow()
        {

            InitializeComponent();
            TXB_equation.Text = equation;
        }
        /* NUMERI */
        public void BTN_1_Click(object sender, RoutedEventArgs e)
        {
            equation = equation+"1";
            TXB_equation.Text = equation;
        }
        public void BTN_2_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "2";
            TXB_equation.Text = equation;
        }
        public void BTN_3_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "3";
            TXB_equation.Text = equation;
        }
        public void BTN_4_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "4";
            TXB_equation.Text = equation;
        }
        public void BTN_5_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "5";
            TXB_equation.Text = equation;
        }
        public void BTN_6_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "6";
            TXB_equation.Text = equation;
        }
        public void BTN_7_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "7";
            TXB_equation.Text = equation;
        }
        public void BTN_8_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "8";
            TXB_equation.Text = equation;
        }
        public void BTN_9_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "9";
            TXB_equation.Text = equation;
        }
        public void BTN_0_Click(object sender, RoutedEventArgs e)
        {
            equation = equation + "0";
            TXB_equation.Text = equation;

        }

        private void BTN_PLUS_Click(object sender, RoutedEventArgs e)
        {
            char equationhelper = TXB_equation.Text[TXB_equation.Text.Length-1];
            if (equationhelper != '+' && equationhelper != '-' && equationhelper != '*' && equationhelper != '.')
            {
                equation = equation + "+";
                TXB_equation.Text = equation;
            }
        }
    }
}