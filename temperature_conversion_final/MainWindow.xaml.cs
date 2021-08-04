using System;
using System.Collections.Generic;
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

namespace temperature_conversion_final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool counting;
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            var source = (TextBox)sender;

            if (counting != true)
            {
                counting = true;
                Celsius.BorderBrush = Brushes.Black;
                Kelvin.BorderBrush = Brushes.Black;
                Fahrenheit.BorderBrush = Brushes.Black;

                if (source == Fahrenheit)
                {
                    try
                    {
                        Celsius.Text = (0.5555555 * (float.Parse(Fahrenheit.Text) - 32)).ToString();
                        Kelvin.Text = (float.Parse(Celsius.Text) + 273.15).ToString();
                    }
                    catch
                    {
                        Celsius.Text = "";
                        Kelvin.Text = "";
                        Celsius.BorderBrush = Brushes.Red;
                        Kelvin.BorderBrush = Brushes.Red;
                        counting = false;
                    }
                }
                else if (source == Celsius)
                {
                    try
                    {
                        Fahrenheit.Text = (1.8 * (float.Parse(Celsius.Text) + 32)).ToString();
                        Kelvin.Text = (float.Parse(Celsius.Text) + 273.15).ToString();
                    }
                    catch
                    {
                        Kelvin.Text = ""; 
                        Fahrenheit.Text = "";
                        Kelvin.BorderBrush = Brushes.Red;
                        Fahrenheit.BorderBrush = Brushes.Red;
                        counting = false;
                    }
                }
                else if (source == Kelvin)
                {
                    try
                    {
                        Celsius.Text = (float.Parse(Kelvin.Text) - 273.15).ToString();
                        Fahrenheit.Text = (1.8 * (float.Parse(Celsius.Text) + 32)).ToString();
                    }
                    catch
                    {
                        Celsius.Text = "";
                        Fahrenheit.Text = "";
                        Celsius.BorderBrush = Brushes.Red;
                        Fahrenheit.BorderBrush = Brushes.Red;
                        counting = false;
                    }
                }

                counting = false;
            }
        }
    }
}
