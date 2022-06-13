using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Windows7_Calc
{
    public class CalcHandle
    {
        private const int MAX_DIGITS = 15;
        private const int MAX_DIGITS_AFTER_COMMA = 9;

        public double Accumulator { get; private set; } = 0.0;
        public double CurrNumber { get; private set; } = 0.0;
        public double Answer { get; private set; } = 0.0;

        //Состояния калькулятора
        private enum State
        {
            N, Exponent, Answer, Error,
                Add, Subs, Mult, Div,
                Sqr
        }
        private State CurrentState = State.N;

        public string CurrentError = "";
        public bool IsError()
        {
            return CurrentState == State.Error;
        }

        bool IsAddComma = false;
        public void AddComma()
        {
            IsAddComma = true;
        }
        public void AddDigit(string Digit)
        {
            if (CurrentState == State.Answer
                || CurrentState == State.Error)
            {
                Accumulator = 0.0;
                CurrNumber = Buffer = 0.0;
                CurrentState = State.N;

                CurrentError = "";
            }

            string _CurrNumber = CurrNumber.ToString();

            if (_CurrNumber.Length >= MAX_DIGITS
                || _CurrNumber.Contains("E"))
                return;

            if (_CurrNumber == "0" && !IsAddComma)
                _CurrNumber = Digit;

            else
            {
                if (!_CurrNumber.Contains(",") && IsAddComma == true)
                {
                    _CurrNumber += ",";
                    IsAddComma = false;
                }
                _CurrNumber += Digit;
            }

            CurrNumber = Buffer = Convert.ToDouble(_CurrNumber);
        }
        public void SetNumber(string Num)
        {
            CurrNumber = Buffer = Convert.ToDouble(Num);
        }
        public void RemoveDigit()
        {
            IsAddComma = false;

            if (CurrentState == State.Answer)
                return;

            string _CurrNumber = CurrNumber.ToString();

            if (_CurrNumber.Length > 2)
                _CurrNumber = _CurrNumber.Remove(_CurrNumber.Length - 1, 1);

            else if (_CurrNumber.Length == 1)
                _CurrNumber = "0";

            CurrNumber = Buffer = Convert.ToDouble(_CurrNumber);
        }
        public void Remove_CE()
        {
            IsAddComma = false;
            CurrNumber = Buffer = 0.0;
        }
        public void Remove_C()
        {
            IsAddComma = false;

            CurrNumber = Buffer = Accumulator = 0.0;

            CurrentState = State.N;
            CurrentExpression = CurrentError = "";
        }

        public string CurrentExpression { get; private set; } = "";
        private Dictionary<string, string> Operations = new Dictionary<string, string>()
        {
            { "Plus", "+" },
            { "Minus", "-" },
            { "Multiplication", "×"},
            { "Division", "÷"},
            { "SquareRoot", "√"},
            { "Percent", "%"}
        };
        private Dictionary<string, string> Errors = new Dictionary<string, string>()
        {
            { "DivisionByZero", "Деление на 0 невозможно" },
            { "IncorrentInput", "Неверный ввод" }
        };

        public void Addition()
        {
            IsAddComma = false;

            if (CurrentState == State.N || CurrentState == State.Answer)
                Accumulator = CurrNumber;

            else
                Accumulator += CurrNumber;

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentExpression += Buffer.ToString() + " "
                + Operations["Plus"] + " ";

            CurrentState = State.Add;
            CurrNumber = Buffer = 0.0;
        }
        public void Subtraction()
        {
            IsAddComma = false;

            if (CurrentState == State.N || CurrentState == State.Answer)
                Accumulator = CurrNumber;

            else
                Accumulator -= CurrNumber;

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentExpression += Buffer.ToString() + " "
                + Operations["Minus"] + " ";

            CurrentState = State.Subs;
            CurrNumber = Buffer = 0.0;
        }
        public void Multiplication()
        {
            IsAddComma = false;

            if (CurrentState == State.N || CurrentState == State.Answer)
                Accumulator = CurrNumber;

            else
                Accumulator *= CurrNumber;

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentExpression += Buffer.ToString() + " "
                + Operations["Multiplication"] + " ";

            CurrentState = State.Mult;
            CurrNumber = Buffer = 0.0;
        }
        public void Division()
        {
            IsAddComma = false;

            if (CurrentState == State.N || CurrentState == State.Answer)
                Accumulator = CurrNumber;

            else
            {
                if (CurrNumber == 0)
                {
                    CurrentState = State.Error;
                    CurrentError = Errors["DivisionByZero"];
                    return;
                }
                Accumulator /= CurrNumber;
            }

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentExpression += Buffer.ToString() + " "
                + Operations["Division"] + " ";

            CurrentState = State.Div;
            CurrNumber = Buffer = 0.0;
        }

        //История операций
        public ObservableCollection<string> CalcHistory { get; private set; } 
            = new ObservableCollection<string>();

        public void Equals()
        {
            switch (CurrentState)
            {
                case State.Add:
                    Accumulator += CurrNumber;
                    break;

                case State.Subs:
                    Accumulator -= CurrNumber;
                    break;

                case State.Mult:
                    Accumulator *= CurrNumber;
                    break;

                case State.Div:
                    if (CurrNumber == 0.0)
                    {
                        CurrentState = State.Error;
                        CurrentError = Errors["DivisionByZero"];
                        return;
                    }

                    Accumulator /= CurrNumber;
                    break;

                case State.Sqr:
                    Accumulator = CurrNumber;
                    break;
            }

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentState = State.Answer;
            CurrentExpression = "";

            CalcHistory.Add(Accumulator.ToString());
            CurrNumber = Buffer = Accumulator;

            IsSqrt = false;
        }

        public void SignSwitch()
        {
            CurrNumber = CurrNumber * -1;
        }

        private double Buffer = 0.0;
        private bool IsSqrt = false;
        public void Sqrt()
        {
            if (CurrNumber < 0)
            {
                CurrNumber = 0.0;
                CurrentState = State.Error;
                CurrentError = Errors["IncorrentInput"];
                return;
            }

            if (CurrentState == State.N)
                CurrentState = State.Sqr;

            CurrentExpression += Operations["SquareRoot"];
            CurrNumber = Math.Round(Math.Sqrt(CurrNumber), MAX_DIGITS_AFTER_COMMA);
        }
        /*
        public void Reverse()
        {
            double X = Convert.ToDouble(Accumulator);
            Accumulator = Convert.ToString(Math.Round(1 / X, MAX_DIGITS_AFTER_COMMA));
            CalcHistory.Add(Accumulator);
        }
        public void Percent()
        {
            IsPercent = true;
        }

        //Число в памяти
        private string MemoryCell = "0";
        public void MemoryRead()
        {
            if (CurrentMemoryState != MemoryState.IsEmpty)
            {
                Accumulator = MemoryCell;
            }
        }
        public void MemoryWrite()
        {
            MemoryCell = Accumulator;
            CurrentMemoryState = MemoryState.IsFull;
        }
        public void MemoryClear()
        {
            MemoryCell = "0";
            CurrentMemoryState = MemoryState.IsEmpty;
        }
        private enum MemoryState
        {
            IsEmpty, IsFull
        }
        private MemoryState CurrentMemoryState = MemoryState.IsEmpty;
        public void MemoryPlus()
        {
            if (CurrentMemoryState == MemoryState.IsFull)
            {
                MemoryCell = Convert.ToString(
                    Convert.ToDouble(MemoryCell) + Convert.ToDouble(Accumulator));
            }
        }
        public void MemoryMinus()
        {
            if (CurrentMemoryState == MemoryState.IsFull)
            {
                MemoryCell = Convert.ToString(
                    Convert.ToDouble(MemoryCell) - Convert.ToDouble(Accumulator));
            }
        }
        */
    }
}
