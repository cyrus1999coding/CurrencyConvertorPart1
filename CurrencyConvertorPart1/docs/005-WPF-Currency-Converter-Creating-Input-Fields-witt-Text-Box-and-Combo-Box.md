# 005 WPF Currency Converter - Creating Input Fields with Text Box and Combo Box

```xaml
<TextBox Name="txtCurrency" Width="200" Height="30" Margin="40 0 0 0" PreviewTextInput="NumberValidationTextBox" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top"></TextBox>
```
- <TextBox> :  
  A box which we can enter a text .
- `Name="txtCurrency"` :  
  Because we want to be able to get the Value that the User entered from this <TextBox>, to use in our Program .  
- 🔑`PreviewTextInput="NumberValidationTextBox"` :   
  When somebody enteres something we want them to limited to only enter numbers  
  That's why we created this function → `NumberValidationTextBox`  
  That we need to implement later on .   
  `MainWindow.xaml.cs` :
  ```cs
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

            private void Covert_Click(object sender, RoutedEventArgs e)
            {
                lblCurrency.Content = "Hellow Button Clicker";
            }
            private void Clear_Click(object sender, RoutedEventArgs e)
            {
                lblCurrency.Content = "";
            }

            👇
            private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
            {

            
            }
            👆
        }
    }
  ```
  And we can filter our key strokes that aren't numbers basically .
  

```xaml
<ComboBox Name="cmbFromCurrency" Width="170" Height="30" Margin="60 0 40 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxDropDownHeight="150"></ComboBox>
```
- 🔑`<ComboBox>` :  
  Allows us to select out of Multiple different values .  
  So what are the values that we want to allow to have ? ↓
  `Name="cmbFromCurrency"`, We'll define that in the *Code behind* giving it 🔑`ItemsSource` which is really important  
  because it needs to know that it can display .

```xaml
<fa:ImageAwesome Icon="Exchange" Height="30" Width="30" Foreground="White" VerticalAlignment="Top"></fa:ImageAwesome>
```
- `fa:ImageAwesome` :  
  Then we have this 🔑`ImageAwesome` which we get with NuGet

(Myself) :

`MainWindow.xaml` so far ↓  

```xaml
<Window x:Class="CurrencyConvertorPart1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CurrencyConvertorPart1" xmlns:fa="http://schemas.fontawesome.io/icons/"
        mc:Ignorable="d"
        Title="Currency Converter" SizeToContent="WidthAndHeight" WindowStartupLocation="CenterScreen" Height="450" Width="1000">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="60"></RowDefinition>
            <RowDefinition Height="80"></RowDefinition>
            <RowDefinition Height="150"></RowDefinition>
            <RowDefinition Height="100"></RowDefinition>
            <RowDefinition Height="150"></RowDefinition>
        </Grid.RowDefinitions>

        <Border Grid.Row="2" Width="800" CornerRadius="10" BorderThickness="5">
            <Border.BorderBrush>
                <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                    <GradientStop Color="#ec2075" Offset="0.0" />
                    <GradientStop Color="#f33944" Offset="1.0" />
                </LinearGradientBrush>
            </Border.BorderBrush>
            <Rectangle Grid.Row="2">
                <Rectangle.Fill>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                        <GradientStop Color="#ec2075" Offset="0.0" />
                        <GradientStop Color="#f33944" Offset="0.50" />
                    </LinearGradientBrush>
                </Rectangle.Fill>
            </Rectangle>
        </Border>

        <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Height="50" Width="1000" VerticalAlignment="Center">
            <Label Height="50" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Currency Converter" FontSize="25" Foreground="#ec2075" FontWeight="Bold"></Label>
        </StackPanel>
        <StackPanel Grid.Row="1" Orientation="Vertical" HorizontalAlignment="Center" Height="80" Width="1000">
            <Label Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Converted Currency" FontSize="20"></Label>
            <Label Name="lblCurrency" Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" FontSize="20"></Label>
        </StackPanel>
        <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Top" Height="60" Width="800">
            <Label Height="40" Width="150" Content="Enter Amount : " Margin="35 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
            <Label Height="40" Width="150" Content="From : " Margin="110 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
            <Label Height="40" Width="150" Content="To : " Margin="130 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
        </StackPanel>
        <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" Height="90" Width="800" VerticalAlignment="Bottom">
            <TextBox Name="txtCurrency" Width="200" Height="30" Margin="40 0 0 0" PreviewTextInput="NumberValidationTextBox" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top"></TextBox>
            <ComboBox Name="cmbFromCurrency" Width="170" Height="30" Margin="60 0 40 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxDropDownHeight="150"></ComboBox>
            <fa:ImageAwesome Icon="Exchange" Height="30" Width="30" Foreground="White" VerticalAlignment="Top"></fa:ImageAwesome>
            <ComboBox Name="cmbToCurrency" Width="170" Height="30" Margin="40 0 0 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxDropDownHeight="150"></ComboBox>
        </StackPanel>
        <StackPanel Grid.Row="3" Height="100" Width="1000" Orientation="Horizontal">
            <Button Name="Convert" Height="40" Width="150" Content="Convert" Click="Convert_Click" Margin="350 0 20 0" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                <Button.Background>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                        <GradientStop Color="#ec2075" Offset="0.0"/>
                        <GradientStop Color="#f33944" Offset="0.5"/>
                    </LinearGradientBrush>
                </Button.Background>
            </Button>
            <Button Name="Clear" Height="40" Width="150" Content="Clear" Click="Clear_Click" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                <Button.Background>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                        <GradientStop Color="#ec2075" Offset="0.0"/>
                        <GradientStop Color="#f33944" Offset="0.5"/>
                    </LinearGradientBrush>
                </Button.Background>
            </Button>
        </StackPanel>
    </Grid>
</Window>
```

`MainWindow.xaml.cs` so far ↓

```cs
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
```


```xaml
<Button Name="Convert" Height="40" Width="150" Content="Convert" Click="Convert_Click" Margin="350 0 20 0" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
```
- 🔑`Style="{StaticResource ButtonRound}"` .

