using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            HistoryBox.Content = Calc.CurrentExpression;
        }
        public CalcHandle Calc = new CalcHandle();
       
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("1");
            NumUpdate(Calc.CurrNumber);
        }
       
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("2");
            NumUpdate(Calc.CurrNumber);
        }
        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("3");
            NumUpdate(Calc.CurrNumber);
        }
        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("4");
            NumUpdate(Calc.CurrNumber);
        }
        private void B5_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("5");
            NumUpdate(Calc.CurrNumber);
        }
        private void B6_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("6");
            NumUpdate(Calc.CurrNumber);
        }
        private void B7_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("7");
            NumUpdate(Calc.CurrNumber);
        }
        private void B8_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("8");
            NumUpdate(Calc.CurrNumber);
        }
        private void B9_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("9");
            NumUpdate(Calc.CurrNumber);
        }
        private void B0_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddDigit("0");
            NumUpdate(Calc.CurrNumber);
        }
        
        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            Calc.AddComma();
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Calc.Equals();
            NumUpdate(Calc.Accumulator);
            Journal.ItemsSource = Calc.CalcHistory;
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Calc.Addition();
            NumUpdate(Calc.Accumulator);
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Calc.Subtraction();
            NumUpdate(Calc.Accumulator);
        }
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            Calc.Multiplication();
            NumUpdate(Calc.Accumulator);
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
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
            Calc.Sqrt();
            NumUpdate(Calc.CurrNumber);
        }
        private void OneDivide_Click(object sender, RoutedEventArgs e)
        {
            Calc.Reverse();
            NumUpdate(Calc.CurrNumber);
        }
        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            Calc.Percent();
            NumUpdate(Calc.CurrNumber);
        }
        private void EraseAll_Click(object sender, RoutedEventArgs e)
        {
            Calc.Remove_CE();
            NumUpdate(Calc.CurrNumber);
        }
        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            Calc.Remove_C();
            HistoryBox.Content = "";
            NumUpdate(Calc.CurrNumber);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Calc.RemoveDigit();
            NumUpdate(Calc.CurrNumber);
        }
        //Обработка нажатий клавиатуры
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.NumPad0:
                    B0_Click(null, null);
                    break;
                case Key.D0:
                    B0_Click(null, null);
                    break;

                case Key.NumPad1:
                    B1_Click(null, null);
                    break;
                case Key.D1:
                    B1_Click(null, null);
                    break;

                case Key.NumPad2:
                    B2_Click(null, null);
                    break;
                case Key.D2:
                    B2_Click(null, null);
                    break;

                case Key.NumPad3:
                    B3_Click(null, null);
                    break;
                case Key.D3:
                    B3_Click(null, null);
                    break;

                case Key.NumPad4:
                    B4_Click(null, null);
                    break;
                case Key.D4:
                    B4_Click(null, null);
                    break;

                case Key.NumPad5:
                    B5_Click(null, null);
                    break;
                case Key.D5:
                    B5_Click(null, null);
                    break;

                case Key.NumPad6:
                    B6_Click(null, null);
                    break;
                case Key.D6:
                    B6_Click(null, null);
                    break;

                case Key.NumPad7:
                    B7_Click(null, null);
                    break;
                case Key.D7:
                    B7_Click(null, null);
                    break;

                case Key.NumPad8:
                    B8_Click(null, null);
                    break;
                case Key.D8:
                    B8_Click(null, null);
                    break;

                case Key.NumPad9:
                    B9_Click(null, null);
                    break;
                case Key.D9:
                    B9_Click(null, null);
                    break;

                case Key.Decimal:
                    Comma_Click(null, null);
                    break;

                case Key.Return:
                    Equals_Click(null, null);
                    break;

                case Key.Add:
                    Plus_Click(null, null);
                    break;
                case Key.OemPlus:
                    Plus_Click(null, null);
                    break;

                case Key.Subtract:
                    Minus_Click(null, null);
                    break;
                case Key.OemMinus:
                    Minus_Click(null, null);
                    break;

                case Key.Multiply:
                    Multiply_Click(null, null);
                    break;

                case Key.Divide:
                    Divide_Click(null, null);
                    break;

                case Key.Back:
                    Back_Click(null, null);
                    break;

                case Key.C:
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                        MenuCopyBtn_Click(null, null);
                    break;

                case Key.V:
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                        MenuPasteBtn_Click(null, null);
                    break;
            }
        }

        private void MemoryClearButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryClear();
            MemorySaveButton.Background = 
                new SolidColorBrush(Color.FromRgb(167, 222, 255));
        }

        private void MemorySaveButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryWrite();
            (sender as Button).Background = 
                new SolidColorBrush(Color.FromRgb(93, 194, 255));
        }

        private void MemoryReadButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryRead();
            NumUpdate(Calc.CurrNumber);
        }

        private void MemoryPlusButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryPlus();
        }
            
        private void MemoryMinusButton_Click(object sender, RoutedEventArgs e)
        {
            Calc.MemoryMinus();
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            Journal.Visibility = Visibility.Visible;
        }

        private void MenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            Journal.Visibility = Visibility.Collapsed;
        }

        private void Journal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null)
            {
                Calc.SetNumber((sender as ComboBox).SelectedValue.ToString());
            }
            //MainText.Text = (sender as ComboBox).SelectedValue.ToString();
            (sender as ComboBox).Text = ""; 
            NumUpdate(Calc.CurrNumber);
        }
        private void MenuCopyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, Calc.CurrNumber.ToString());
        }
        private void MenuPasteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsData(DataFormats.Text))
            {
                Calc.SetNumber(Clipboard.GetText());
                NumUpdate(Calc.CurrNumber);
            }
        }
    }
}
