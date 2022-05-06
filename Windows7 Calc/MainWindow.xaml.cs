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
using System.Diagnostics;

namespace Windows7_Calc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        const double MainTextWidth = 293.0;
        const double MainTextFontSize = 38;

        public void NumUpdate(string Number, bool IsError = false)
        {
            if (IsError)
            {
                MainText.Text = "Неверный ввод";
                return;
            }
            MainText.FontSize = Math.Min(MainTextWidth * 1.8 / Number.Length, MainTextFontSize);
            MainText.Text = Number;
            HistoryBox.ItemsSource = Calc.CalcHistory;
        }
        public CalcHandle Calc = new CalcHandle();
        
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
       
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void B5_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void B6_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void B7_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void B8_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void B9_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void B0_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddComma((sender as Button).Content.ToString());
            NumUpdate(Calc.ActiveVariable);
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (Calc.CanEqual)
            {
                HistoryBox.Text += Calc.ActiveVariable + ((Calc.IsPercent) ? "%" : "");
                Calc.Equals();
                NumUpdate(Calc.ActiveVariable);
            }
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (Calc.IsNotBusy())
            {
                HistoryBox.Text = Calc.ActiveVariable + " " +
                    (sender as Button).Content.ToString() + " ";
                Calc.Addition();
                NumUpdate(Calc.ActiveVariable);
            }
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (Calc.IsNotBusy())
            {
                HistoryBox.Text = Calc.ActiveVariable + " " +
                    (sender as Button).Content.ToString() + " ";
                Calc.Subtraction();
                NumUpdate(Calc.ActiveVariable);
            }
        }
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (Calc.IsNotBusy())
            {
                HistoryBox.Text = Calc.ActiveVariable + " " +
                    (sender as Button).Content.ToString() + " ";
                Calc.Multiplication();
                NumUpdate(Calc.ActiveVariable);
            }
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if (Calc.IsNotBusy())
            {
                HistoryBox.Text = Calc.ActiveVariable + " " +
                    (sender as Button).Content.ToString() + " ";
                Calc.Division();
                NumUpdate(Calc.ActiveVariable);
            }
        }
        private void Plus_Min_Click(object sender, RoutedEventArgs e)
        {
            Calc.SignSwitch();
            NumUpdate(Calc.ActiveVariable);
        }
        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            HistoryBox.Text = (sender as Button).Content.ToString() + Calc.ActiveVariable;
            Calc.Sqrt();
            NumUpdate(Calc.ActiveVariable, Calc.IsError());
        }
        private void OneDivide_Click(object sender, RoutedEventArgs e)
        {
            HistoryBox.Text = "1/" + Calc.ActiveVariable;
            Calc.Reverse();
            NumUpdate(Calc.ActiveVariable);
        }
        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            if (Calc.CanEqual && !Calc.IsPercent)
            {
                Calc.Percent();
                MainText.Text += "%";
            }
        }
        private void EraseAll_Click(object sender, RoutedEventArgs e)
        {
            Calc.Remove_CE();
            NumUpdate(Calc.ActiveVariable);
        }
        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            Calc.Remove_C();
            HistoryBox.Text = "";
            NumUpdate(Calc.ActiveVariable);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Calc.RemoveDigit();
            NumUpdate(Calc.ActiveVariable);
        }
        //Обработка нажатий клавиатуры
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumPad0 || e.Key == Key.D0)
            {
                Calc.AddDigit("0");
            }
            if (e.Key == Key.NumPad1 || e.Key == Key.D1)
            {
                Calc.AddDigit("1");
            }
            if (e.Key == Key.NumPad2 || e.Key == Key.D2)
            {
                Calc.AddDigit("2");
            }
            if (e.Key == Key.NumPad3 || e.Key == Key.D3)
            {
                Calc.AddDigit("3");
            }
            if (e.Key == Key.NumPad4 || e.Key == Key.D4)
            {
                Calc.AddDigit("4");
            }
            if (e.Key == Key.NumPad5 || e.Key == Key.D5)
            {
                Calc.AddDigit("5");
            }
            if (e.Key == Key.NumPad6 || e.Key == Key.D6)
            {
                Calc.AddDigit("6");
            }
            if (e.Key == Key.NumPad7 || e.Key == Key.D7)
            {
                Calc.AddDigit("7");
            }
            if (e.Key == Key.NumPad8 || e.Key == Key.D8)
            {
                Calc.AddDigit("8");
            }
            if (e.Key == Key.NumPad9 || e.Key == Key.D9)
            {
                Calc.AddDigit("9");
            }
            
            if (e.Key == Key.Decimal)
            {
                Calc.AddComma(",");
            }

            if (e.Key == Key.Return)
            {
                if (Calc.CanEqual)
                {
                    HistoryBox.Text += Calc.ActiveVariable + ((Calc.IsPercent) ? "%" : "");
                    Calc.Equals();
                }
            }
            if (e.Key == Key.Add || e.Key == Key.OemPlus)
            {
                if (Calc.IsNotBusy())
                {
                    HistoryBox.Text = Calc.ActiveVariable + " + ";
                    Calc.Addition();
                }
            }
            if (e.Key == Key.Subtract || e.Key == Key.OemMinus)
            {
                if (Calc.IsNotBusy())
                {
                    HistoryBox.Text = Calc.ActiveVariable + " - ";
                    Calc.Subtraction();
                }
            }
            if (e.Key == Key.Multiply)
            {
                if (Calc.IsNotBusy())
                {
                    HistoryBox.Text = Calc.ActiveVariable + " × ";
                    Calc.Multiplication();
                }
            }
            if (e.Key == Key.Divide)
            {
                if (Calc.IsNotBusy())
                {
                    HistoryBox.Text = Calc.ActiveVariable + " ÷ ";
                    Calc.Division();
                }
            }

            if (e.Key == Key.Back)
            {
                Calc.RemoveDigit();
            }

            NumUpdate(Calc.ActiveVariable);
        }

        private void MemoryClearButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryClear();
            MemorySaveButton.Background = new SolidColorBrush(Color.FromRgb(167, 222, 255));
        }

        private void MemorySaveButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryWrite();
            (sender as Button).Background = new SolidColorBrush(Color.FromRgb(93, 194, 255));
        }

        private void MemoryReadButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryRead();
            NumUpdate(Calc.ActiveVariable);
        }

        private void MemoryPlusButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryPlus();
        }
            
        private void MemoryMinusButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryMinus();
        }

        private void HistoryBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null)
            {
                Calc.SetNumber((sender as ComboBox).SelectedValue.ToString());
            }
            //MainText.Text = (sender as ComboBox).SelectedValue.ToString();
            NumUpdate(Calc.ActiveVariable);
        }
    }
}
