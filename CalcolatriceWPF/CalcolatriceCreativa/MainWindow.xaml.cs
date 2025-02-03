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
        public bool BTN1 = false; //bool di bottoni, per assicurarsi che l'operazione venga eseguita solo la prima volta
        public bool BTN2 = false;
        public bool BTN3 = false;
        public bool BTN4 = false;
        public bool BTN5 = false;
        public int pplcounter = 0; //Conteggio persone
        public MainWindow()
        {

            InitializeComponent();
            TXB_equation.Text = equation;
            LBL_ppl.Content = "Persone Trovate: " + Convert.ToString(pplcounter); //Conteggio persone
        }
        public void UpdateLBL()
        {
            pplcounter++;
            LBL_ppl.Content = "Persone Trovate: " + Convert.ToString(pplcounter); //Aggiornamento conteggio
        }
        public void PersonFound(bool BTN,string Name) //Aggiunta persone con aggiornamento integrato
        {
            if (BTN == false)
            {
                MessageBox.Show(Name);
                UpdateLBL();
                BTN = true;
            }
        }
        /* NUMERI */
        public void EquationHandlerNum(char num) //Equazione
        {
            equation += num;
            TXB_equation.Text=equation;
        }
        //BOTTONI
        public void BTN_1_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('1');
            PersonFound(BTN1 , "Eduardo Garcia Lòpez");
        }
        public void BTN_2_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('2');
            PersonFound(BTN2, "Nicky Kiwi");
            BTN2 = true;
        }
        public void BTN_3_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('3');
            PersonFound(BTN3, "Carlo Carota");
            BTN3 = true;
        }
        public void BTN_4_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('4');
            PersonFound(BTN4, "Lupo Lucio");
            BTN4 = true;
        }
        public void BTN_5_Click(object sender, RoutedEventArgs e)
        {
            EquationHandlerNum('5');
            PersonFound(BTN5, "Paolo Prugna");
            BTN5 = true;
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
        public void EquationHandlerOp(char op) { //Si occupa degli operandi
            char equationhelper = TXB_equation.Text[TXB_equation.Text.Length - 1];
            if (equationhelper != '+' && equationhelper != '-' && equationhelper != '*' && equationhelper != '.')
            {
                equation = equation + op;
                TXB_equation.Text = equation;
            }
        }
        public void EquationDeleter() //Rimuove il contenuto dell'equazione
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

        private void BTN_NEGATE_Click(object sender, RoutedEventArgs e) //Nega l'ultimo numero inserito dopo dell'operando
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

        private void BTN_CANC_Click(object sender, RoutedEventArgs e) //Cancella l'ultimo input
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

        private void BTN_EQU_Click(object sender, RoutedEventArgs e) //Output del risultato
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