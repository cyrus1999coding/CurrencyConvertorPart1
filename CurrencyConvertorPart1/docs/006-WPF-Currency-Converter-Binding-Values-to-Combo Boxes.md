# 006 WPF Currency Converter - Binding Values to Combo Boxes

`MainWindow.xaml.cs`

```cs
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
        👇
        private void BindCurrenct()
        {
            DataTable dlCurrency = new DataTable();
            dlCurrency.Columns.Add("Text");
            dlCurrency.Columns.Add("Value");
        }
        👆
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
```

- Basically we're creating `Table` here and that Table has 2 `Columns` and the `Rows` we're going to add next .

`MainWindow.xaml.cs` :

```cs
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

        private void BindCurrenct()
        {
            DataTable dlCurrency = new DataTable();
            dlCurrency.Columns.Add("Text");
            dlCurrency.Columns.Add("Value");
            👇
            //Add rows in the DataTable with text and value  
            dlCurrency.Rows.Add("--SElEct--", 0);
            dlCurrency.Rows.Add("INR", 1);
            dlCurrency.Rows.Add("USD", 75);
            dlCurrency.Rows.Add("EUR", 85);
            dlCurrency.Rows.Add("SAR", 20);
            dlCurrency.Rows.Add("POUND", 5);
            dlCurrency.Rows.Add("DEM", 43);
            👆
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
```

And then :

`MainWindow.xaml.cs` :

```cs
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

        private void BindCurrenct()
        {
            DataTable dlCurrency = new DataTable();
            dlCurrency.Columns.Add("Text");
            dlCurrency.Columns.Add("Value");
            //Add rows in the DataTable with text and value  
            dlCurrency.Rows.Add("--Select--", 0);
            dlCurrency.Rows.Add("INR", 1);
            dlCurrency.Rows.Add("USD", 75);
            dlCurrency.Rows.Add("EUR", 85);
            dlCurrency.Rows.Add("SAR", 20);
            dlCurrency.Rows.Add("POUND", 5);
            dlCurrency.Rows.Add("DEM", 43);

            cmbFromCurrency.ItemsSource = dlCurrency.DefaultView; 👈
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
```
- `cmbFromCurrency.ItemsSource = dlCurrency.DefaultView;` :  
  By doing this we Assign this `DataType` to be the `.ItemsSource` for *cmbFromCurrency* .

So we need to call this ↓

```cs
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
            BindCurrenct();
        }

        private void BindCurrenct()
        {
            DataTable dlCurrency = new DataTable();

            dlCurrency.Columns.Add("Text");
            dlCurrency.Columns.Add("Value");

            // If we have a Third column 
            dlCurrency.Columns.Add("Temp");

            dlCurrency.Rows.Add("--Select--", 0, 0);

           // If we have a Third column 
           // dlCurrency.Rows.Add("--Select--", 0, 35);

            dlCurrency.Rows.Add("INR", 1);
            dlCurrency.Rows.Add("USD", 75);
            dlCurrency.Rows.Add("EUR", 85);
            dlCurrency.Rows.Add("SAR", 20);
            dlCurrency.Rows.Add("POUND", 5);
            dlCurrency.Rows.Add("DEM", 43);

            cmbFromCurrency.ItemsSource = dlCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dlCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
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
```

Now let's the same thing with our another `<ComboBox />` ↓  

```cs
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
            BindCurrenct();
        }

        private void BindCurrenct()
        {
            DataTable dlCurrency = new DataTable();

            dlCurrency.Columns.Add("Text");
            dlCurrency.Columns.Add("Value");

            dlCurrency.Rows.Add("--Select--", 0);
            dlCurrency.Rows.Add("INR", 1);
            dlCurrency.Rows.Add("USD", 75);
            dlCurrency.Rows.Add("EUR", 85);
            dlCurrency.Rows.Add("SAR", 20);
            dlCurrency.Rows.Add("POUND", 5);
            dlCurrency.Rows.Add("DEM", 43);

            cmbFromCurrency.ItemsSource = dlCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dlCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;

            👇
            cmbToCurrency.ItemsSource = dlCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
            👆

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
```

Now let's Modify our *Convert_Click* `EventHandler`

```cs
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
            BindCurrenct();
        }

        private void BindCurrenct()
        {
            DataTable dlCurrency = new DataTable();

            dlCurrency.Columns.Add("Text");
            dlCurrency.Columns.Add("Value");

            dlCurrency.Rows.Add("--Select--", 0);
            dlCurrency.Rows.Add("INR", 1);
            dlCurrency.Rows.Add("USD", 75);
            dlCurrency.Rows.Add("EUR", 85);
            dlCurrency.Rows.Add("SAR", 20);
            dlCurrency.Rows.Add("POUND", 5);
            dlCurrency.Rows.Add("DEM", 43);

            cmbFromCurrency.ItemsSource = dlCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dlCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dlCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
           

        }
        👇
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            //Create a variable as ConvertedValue with double data type to store currency converted value
            double ConvertedValue;

            //Check amount textbox is Null or Blank
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                //If amount textbox is Null or Blank it will show the below message box   
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //After clicking on message box OK sets the Focus on amount textbox
                txtCurrency.Focus();
                return;
            }
            //Else if the currency from is not selected or it is default text --SELECT--
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                //It will show the message
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Set focus on From Combobox
                cmbFromCurrency.Focus();
                return;
            }
            //Else if Currency To is not Selected or Select Default Text --SELECT--
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                //It will show the message
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Set focus on To Combobox
                cmbToCurrency.Focus();
                return;
            }
        }
        👆
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
```