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

namespace CurrencyConvertorPart1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblCurrency.Content = "Hello World!";
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            lblCurrency.Content = "Hellow Button Clicker";
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //txtCurrency.Clear(); GTP
            lblCurrency.Content = "";
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Validation code
        }
    }
}