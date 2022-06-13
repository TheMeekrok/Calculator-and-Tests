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
                Add, Subs, Mult, Div
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
                CurrNumber = 0.0;
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

            CurrNumber = Convert.ToDouble(_CurrNumber);
        }
        
        public void SetNumber(string Num)
        {
            CurrNumber = Convert.ToDouble(Num);
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

            CurrNumber = Convert.ToDouble(_CurrNumber);
        }
        public void Remove_CE()
        {
            IsAddComma = false;
            CurrNumber = 0.0;
        }
        public void Remove_C()
        {
            IsAddComma = false;

            CurrNumber = 0.0;
            Accumulator = 0.0;

            CurrentState = State.N;
            CurrentError = "";
        }

        public void Addition()
        {
            if (CurrentState == State.N
                || CurrentState == State.Answer)
                Accumulator = CurrNumber;

            else
                Accumulator += CurrNumber;

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentState = State.Add;
            CurrNumber = 0.0;

            _Sqrt = false;
        }
        public void Subtraction()
        {
            if (CurrentState == State.N 
                || CurrentState == State.Answer)
                Accumulator = CurrNumber;

            else
                Accumulator -= CurrNumber;

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentState = State.Subs;
            CurrNumber = 0.0;

            _Sqrt = false;
        }
        public void Multiplication()
        {
            if (CurrentState == State.N
                || CurrentState == State.Answer)
                Accumulator = CurrNumber;

            else
                Accumulator *= CurrNumber;

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentState = State.Mult;
            CurrNumber = 0.0;

            _Sqrt = false;
        }
        public void Division()
        {
            if (CurrentState == State.N
                || CurrentState == State.Answer)
                Accumulator = CurrNumber;

            else
            {
                if (CurrNumber == 0.0)
                {
                    CurrentState = State.Error;
                    CurrentError = "Деление на 0 невозможно";
                    return;
                }
                Accumulator /= CurrNumber;
            }

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            CurrentState = State.Div;
            CurrNumber = 0.0;

            _Sqrt = false;
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
                        CurrentError = "Деление на 0 невозможно";
                        return;
                    }
                    Accumulator /= CurrNumber;
                    break;
            }

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            if (_Sqrt && CurrentState == State.N)
            {
                CalcHistory.Add(CurrNumber.ToString());
                CurrentState = State.Answer;
                _Sqrt = false;
                return;
            }

            CurrentState = State.Answer;
            _Sqrt = false;

            CalcHistory.Add(Accumulator.ToString());
            CurrNumber = Accumulator;
        }

        public void SignSwitch()
        {
            CurrNumber = CurrNumber * -1;
        }
        public bool _Sqrt { get; private set; } = false;
        public double Buffer { get; private set; } = 0.0;
        public void Sqrt()
        {
            if (CurrNumber < 0)
            {
                CurrNumber = 0.0;
                CurrentState = State.Error;
                CurrentError = "Недопустимый ввод";
            }
            else
            {
                if (!_Sqrt)
                    Buffer = CurrNumber;
                CurrNumber = Math.Round(Math.Sqrt(CurrNumber), MAX_DIGITS_AFTER_COMMA);
                _Sqrt = true;
            }
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
