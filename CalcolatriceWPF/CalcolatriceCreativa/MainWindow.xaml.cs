using System.Data;
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
        public void EquationHandlerNum(char num)
        {
            equation += num;
            TXB_equation.Text=equation;
        }
        public void BTN_1_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('1');
        }
        public void BTN_2_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('2');
        }
        public void BTN_3_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('3');
        }
        public void BTN_4_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('4');
        }
        public void BTN_5_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('5');
        }
        public void BTN_6_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('6');
        }
        public void BTN_7_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('7');
        }
        public void BTN_8_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('8');
        }
        public void BTN_9_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('9');
        }
        public void BTN_0_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('0');
        }
        /* OPERATORI */
        public void EquationHandlerOp(char op) {
            char equationhelper = TXB_equation.Text[TXB_equation.Text.Length - 1];
            if (equationhelper != '+' && equationhelper != '-' && equationhelper != '*' && equationhelper != '.')
            {
                equation = equation + op;
                TXB_equation.Text = equation;
            }
        }
        public void EquationDeleter()
        {
            equation = "";
            TXB_equation.Text=equation;
        }
        private void BTN_PLUS_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerOp('+');
        }

        private void BTN_MINUS_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerOp('-');
        }

        private void BTN_MULTI_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerOp('*');
        }

        private void BTN_DOT_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerOp('.');
        }

        private void BTN_NEGATE_Click(object sender, RoutedEventArgs e)
        {
            var parts = equation.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0) {
                string lastNumber = parts[parts.Length - 1];
                string negatedNumber = "-" + lastNumber;
                string newEquation = equation.Substring(0, equation.LastIndexOf(lastNumber)) + negatedNumber;
                equation = newEquation;
            }
            TXB_equation.Text = equation;
        }

        private void BTN_CANC_Click(object sender, RoutedEventArgs e)
        {
            string newEquation = "";
            for (int i = 0; i < equation.Length-1; i++) {
                newEquation += equation[i];
            }
            equation = newEquation;
            TXB_equation.Text = equation;
        }

        private void BTN_DELETE_Click(object sender, RoutedEventArgs e)
        {
            EquationDeleter();
        }

        private void BTN_DELETEALL_Click(object sender, RoutedEventArgs e)
        {
            EquationDeleter();
        }

        private void BTN_PERCENT_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non ho voglia di programmarlo sinceramente");
        }

        private void BTN_EQU_Click(object sender, RoutedEventArgs e)
        {
            if (equation[equation.Length-1] =='+' && equation[equation.Length-1]=='-' && equation[equation.Length - 1] == '.')
            {
                equation += "0";
            }
            else if (equation[equation.Length - 1] == '*')
            {
                equation += "1";
            }
            try
            {
                var result = new DataTable().Compute(equation, null);

                double resolver = Convert.ToDouble(result);
                resolver += 0;
                TXB_equation.Text = Convert.ToString(resolver);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}