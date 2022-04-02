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

namespace CalculatorWPF
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
        public double calculator(string a, string b, string op)
        {
            if (op == "+")
            {
                return double.Parse(a) + double.Parse(b);
            }
            else if (op == "-")
            {
                return double.Parse(a) - double.Parse(b);
            }
            else if (op == "x")
            {
                return double.Parse(a) * double.Parse(b);
            }
            else if (op == "÷")
            {
                if (double.Parse(b) == 0)
                {
                    MessageBox.Show("Zero divison error!");
                    return 0;
                }
                return double.Parse(a) / double.Parse(b);
            }
            return 0;
        }
        static string a = "", b = "", op = "";

        private void Click(object sender, EventArgs e)
        {
            
            if (sender is Button)
            {
                Button button = (Button)sender;
                if (button.Content.ToString() == "0" || button.Content.ToString() == "1" || button.Content.ToString() == "2" || button.Content.ToString() == "3" || button.Content.ToString() == "4" || button.Content.ToString() == "5" || button.Content.ToString() == "6" || button.Content.ToString() == "7" || button.Content.ToString() == "8" || button.Content.ToString() == "9")
                {
                    if (result.Text == "0" || result.Text == "+" || result.Text == "-" || result.Text == "x" || result.Text == "÷") { result.Text = button.Content.ToString(); }
                    else
                    {
                        result.Text += button.Content.ToString();
                    }
                }
                else if (button.Content.ToString() == "+" || button.Content.ToString() == "-" || button.Content.ToString() == "x" || button.Content.ToString() == "÷")
                {
                    if (result.Text == "+" || result.Text == "-" || result.Text == "x" || result.Text == "÷")
                    {
                        result.Text = button.Content.ToString();
                        op = button.Content.ToString();
                    }
                    else
                    {
                        a = result.Text;
                        op = button.Content.ToString();
                        result.Text = button.Content.ToString();
                    }
                }
                else if (button.Content.ToString() == "=")
                {
                    if (a != "" && op != "")
                    {
                        b = result.Text;
                        result.Text = calculator(a, b, op).ToString();
                    }
                    else
                    {
                        result.Text = calculator(a, b, op).ToString();
                        a = "";
                        op = "";
                    }
                }
                else if (button.Content.ToString() == "x²")
                {
                    if (result.Text != "")
                    {
                        a = result.Text;
                        op = "x²";
                        result.Text = calculator(a, b, op).ToString();
                    }
                    else
                    {
                        result.Text = calculator(a, b, op).ToString();
                        a = "";
                        op = "";
                    }
                }
                else if (button.Content.ToString() == "C")
                {
                    result.Text = "0";
                    if (op == "")
                    {
                        a = "";
                    }
                    else if (b == "")
                    {
                        op = "";
                    }
                }
                else if (button.Content.ToString() == "⌫")
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1);
                }

            }
        }
    }
}