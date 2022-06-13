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

        double MainTextWidth;
        double MainTextFontSize;
        private void MainWindow1_Loaded(object sender, EventArgs e)
        {
            MainTextWidth = MainText.ActualWidth;
            MainTextFontSize = MainText.FontSize;
        }
        public void NumUpdate(double Number)
        {
            string Text = Calc.IsError() ? Calc.CurrentError : Number.ToString();

            MainText.FontSize = Math.Min(MainTextWidth * 1.85 / Text.Length, MainTextFontSize);
            MainText.Text = Text;
        }
        public CalcHandle Calc = new CalcHandle();
       
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
       
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        private void B5_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        private void B6_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        private void B7_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        private void B8_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        private void B9_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        private void B0_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit((sender as Button).Content.ToString());
            NumUpdate(Calc.CurrNumber);
        }
        
        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddComma();
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            HistoryBox.Text += Calc.CurrNumber.ToString();
            HistoryBox.Text = "";
            Calc.Equals();
            NumUpdate(Calc.Accumulator);

            HistoryBox.ItemsSource = Calc.CalcHistory;
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            HistoryBox.Text += ((Calc._Sqrt) ? Calc.Buffer.ToString() : Calc.CurrNumber.ToString()) 
                + " " + (sender as Button).Content.ToString() + " ";
            Calc.Addition();
            NumUpdate(Calc.Accumulator);
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            HistoryBox.Text += ((Calc._Sqrt) ? Calc.Buffer.ToString() : Calc.CurrNumber.ToString())
                + " " + (sender as Button).Content.ToString() + " ";
            Calc.Subtraction();
            NumUpdate(Calc.Accumulator);
        }
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            HistoryBox.Text += ((Calc._Sqrt) ? Calc.Buffer.ToString() : Calc.CurrNumber.ToString())
                + " " + (sender as Button).Content.ToString() + " ";
            Calc.Multiplication();
            NumUpdate(Calc.Accumulator);
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            HistoryBox.Text += ((Calc._Sqrt) ? Calc.Buffer.ToString() : Calc.CurrNumber.ToString())
                + " " + (sender as Button).Content.ToString() + " ";
            Calc.Division();
            NumUpdate(Calc.Accumulator);
        }
        private void Plus_Min_Click(object sender, RoutedEventArgs e)
        {
            Calc.SignSwitch();
            NumUpdate(Calc.CurrNumber);
        }
        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            HistoryBox.Text += (sender as Button).Content.ToString();
            Calc.Sqrt();
            NumUpdate(Calc.CurrNumber);
        }
        private void OneDivide_Click(object sender, RoutedEventArgs e)
        {/*
            HistoryBox.Text = "1/" + Calc.Accumulator;
            Calc.Reverse();
            NumUpdate(Calc.Accumulator);*/
        }
        private void Percent_Click(object sender, RoutedEventArgs e)
        {/*
            if (Calc.CanEqual && !Calc.IsPercent)
            {
                Calc.Percent();
                MainText.Text += "%";
            }*/
        }
        private void EraseAll_Click(object sender, RoutedEventArgs e)
        {
            Calc.Remove_CE();
            NumUpdate(Calc.CurrNumber);
        }
        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            Calc.Remove_C();
            HistoryBox.Text = "";
            NumUpdate(Calc.CurrNumber);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Calc.RemoveDigit();
            NumUpdate(Calc.CurrNumber);
        }
        //Обработка нажатий клавиатуры
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {/*
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
                Calc.AddComma();
            }

            if (e.Key == Key.Return)
            {
                if (Calc.CanEqual)
                {
                    HistoryBox.Text += Calc.Accumulator + ((Calc.IsPercent) ? "%" : "");
                    Calc.Equals();
                }
            }
            if (e.Key == Key.Add || e.Key == Key.OemPlus)
            {
                if (Calc.IsNotBusy())
                {
                    HistoryBox.Text = Calc.Accumulator + " + ";
                    Calc.Addition();
                }
            }
            if (e.Key == Key.Subtract || e.Key == Key.OemMinus)
            {
                if (Calc.IsNotBusy())
                {
                    HistoryBox.Text = Calc.Accumulator + " - ";
                    Calc.Subtraction();
                }
            }
            if (e.Key == Key.Multiply)
            {
                if (Calc.IsNotBusy())
                {
                    HistoryBox.Text = Calc.Accumulator + " × ";
                    Calc.Multiplication();
                }
            }
            if (e.Key == Key.Divide)
            {
                if (Calc.IsNotBusy())
                {
                    HistoryBox.Text = Calc.Accumulator + " ÷ ";
                    Calc.Division();
                }
            }

            if (e.Key == Key.Back)
            {
                Calc.RemoveDigit();
            }

            NumUpdate(Calc.Accumulator);*/
        }

        private void MemoryClearButton_Click(object sender, RoutedEventArgs e)
        {/*
            Calc.MemoryClear();
            MemorySaveButton.Background = new SolidColorBrush(Color.FromRgb(167, 222, 255));*/
        }

        private void MemorySaveButton_Click(object sender, RoutedEventArgs e)
        {/*
            Calc.MemoryWrite();
            (sender as Button).Background = new SolidColorBrush(Color.FromRgb(93, 194, 255));*/
        }

        private void MemoryReadButton_Click(object sender, RoutedEventArgs e)
        {/*
            Calc.MemoryRead();
            NumUpdate(Calc.Accumulator);*/
        }

        private void MemoryPlusButton_Click(object sender, RoutedEventArgs e)
        {
           // Calc.MemoryPlus();
        }
            
        private void MemoryMinusButton_Click(object sender, RoutedEventArgs e)
        {
            //Calc.MemoryMinus();
        }

        private void HistoryBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {/*
            if ((sender as ComboBox).SelectedValue != null)
            {
                Calc.SetNumber((sender as ComboBox).SelectedValue.ToString());
            }
            //MainText.Text = (sender as ComboBox).SelectedValue.ToString();
            NumUpdate(Calc.Accumulator);*/
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            HistoryBox.Visibility = Visibility.Visible;
        }

        private void MenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            HistoryBox.Visibility = Visibility.Hidden;
        }

        private void EngineerModeBtn_Click(object sender, RoutedEventArgs e)
        {
            double WindowWidth = MainWindow1.Width;
            for (double i = WindowWidth; i < WindowWidth * 2; i += 2)
            {
                MainWindow1.Width = i;
            }
        }

        private void CommonModeBtn_Click(object sender, RoutedEventArgs e)
        {
            double WindowWidth = MainWindow1.Width;
            for (double i = WindowWidth; i > WindowWidth / 2; i -= 2)
            {
                MainWindow1.Width = i;
            }
        }
    }
}
