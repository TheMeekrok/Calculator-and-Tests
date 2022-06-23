using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Windows7_Calc
{
    public class CalcHandle
    {
        private const int MAX_DIGITS = 15;
        private const int MAX_DIGITS_AFTER_COMMA = 9;
        private const int MAX_VISIBLE_LENGTH = 45;

        public double Accumulator { get; private set; } = 0.0;

        public double CurrNumber { get; private set; } = 0.0;
        private double Buffer = 0.0;

        //Состояния калькулятора
        private enum State
        {
            N, Exponent, Answer, Error,
                Add, Subs, Mult, Div,
                Sqr, Rev
        }
        private State CurrentState = State.N;

        public string CurrentError = "";
        public bool IsError()
        {
            return CurrentState == State.Error;
        }

        bool IsAddComma = false, CanChangeNum = true;
        public void AddComma()
        {
            IsAddComma = true;
        }
        public void AddDigit(string Digit)
        {
            if (!CanChangeNum)
            {
                CanChangeNum = true;
                CurrNumber = Buffer = 0;
            }

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
            double Temp;
            Double.TryParse(Num, out Temp);

            if (Temp == 0.0)
                return;

            CurrNumber = Buffer = Temp;
        }
        public void RemoveDigit()
        {
            IsAddComma = false;

            string _CurrNumber = CurrNumber.ToString();


            if (CurrentState == State.Answer || _CurrNumber.Contains("E"))
                return;

            if (_CurrNumber.Length >= 2)
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

        //Операции
        private string _CurrentExpression = "";
        public string CurrentExpression
        {
            get
            {
                return _CurrentExpression;
            }
            private set
            {
                _CurrentExpression = value;
                if (_CurrentExpression.Length >= MAX_VISIBLE_LENGTH)
                {
                    _CurrentExpression = _CurrentExpression.Remove(
                        0, _CurrentExpression.Length - MAX_VISIBLE_LENGTH);
                }
            }
        }
        private Dictionary<string, string> Operations = new Dictionary<string, string>()
        {
            { "Plus", "+" },
            { "Minus", "-" },
            { "Multiplication", "×"},
            { "Division", "÷"},
            { "SquareRoot", "√"},
        };
        private Dictionary<string, string> Errors = new Dictionary<string, string>()
        {
            { "DivisionByZero", "Деление на 0 невозможно" },
            { "IncorrentInput", "Неверный ввод" }
        };

        private void OperationHandle(State State)
        {
            switch (State)
            {
                case State.N:
                    Accumulator = CurrNumber;
                    break;

                case State.Answer:
                    Accumulator = CurrNumber;
                    break;

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
                        CurrentExpression = "";
                        CurrentError = Errors["DivisionByZero"];
                        return;
                    }

                    Accumulator /= CurrNumber;
                    break;

                case State.Sqr:
                    Accumulator = CurrNumber;
                    break;

                case State.Rev:
                    Accumulator = CurrNumber;
                    break;
            }

            IsAddComma = IsReversed = false;
            CanChangeNum = false;

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);
        }

        public void Addition()
        {
            OperationHandle(CurrentState);

            CurrentExpression += Buffer.ToString() + " "
                + Operations["Plus"] + " ";

            CurrentState = State.Add;
        }
        public void Subtraction()
        {
            OperationHandle(CurrentState);

            CurrentExpression += Buffer.ToString() + " "
                + Operations["Minus"] + " ";

            CurrentState = State.Subs;
           
        }
        public void Multiplication()
        {
            OperationHandle(CurrentState);

            CurrentExpression += Buffer.ToString() + " "
                + Operations["Multiplication"] + " ";

            CurrentState = State.Mult;
            
        }
        public void Division()
        {
            OperationHandle(CurrentState);

            CurrentExpression += Buffer.ToString() + " "
                + Operations["Division"] + " ";

            CurrentState = State.Div;
           
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
                        CurrentExpression = "";
                        CurrentError = Errors["DivisionByZero"];
                        return;
                    }

                    Accumulator /= CurrNumber;
                    break;

                case State.Sqr:
                    Accumulator = CurrNumber;
                    break;

                case State.Rev:
                    Accumulator = CurrNumber;
                    break;
            }

            Accumulator = Math.Round(Accumulator, MAX_DIGITS_AFTER_COMMA);

            //CurrentState = State.Answer;
            CurrentExpression = "";

            CalcHistory.Add(Accumulator.ToString());
            //CurrNumber = Buffer = Accumulator;
        }

        public void SignSwitch()
        {
            CurrNumber = CurrNumber * -1;
        }

        public void Sqrt()
        {
            if (CurrNumber < 0)
            {
                CurrNumber = Accumulator = 0.0;

                CurrentState = State.Error;
                CurrentError = Errors["IncorrentInput"];
                return;
            }

            if (CurrentState == State.N)
                CurrentState = State.Sqr;

            CurrentExpression += Operations["SquareRoot"];
            CurrNumber = Math.Round(Math.Sqrt(CurrNumber), MAX_DIGITS_AFTER_COMMA);
        }

        private bool IsReversed = false;
        public void Reverse()
        {
            if (CurrNumber == 0.0)
            {
                CurrentState = State.Error;
                CurrentError = Errors["DivisionByZero"];
                return;
            }

            if (CurrentState == State.N)
                CurrentState = State.Rev;

            if (IsReversed)
            {
                CurrentExpression = CurrentExpression.Remove(
                    CurrentExpression.Length - 2, 2);

                CurrNumber = Buffer;
                IsReversed = false;
            }

            else
            {
                CurrentExpression += "1/";

                CurrNumber = Math.Round(1 / CurrNumber, MAX_DIGITS_AFTER_COMMA);
                IsReversed = true;
            }
        }
        public void Percent()
        {
            if (CurrentState != State.N || CurrentState != State.Error)
                CurrNumber = Buffer = Math.Round(
                    Accumulator * CurrNumber / 100, MAX_DIGITS_AFTER_COMMA);
        }

        //Число в памяти
        private double MemoryCell = 0.0;
        public bool MemoryIsFull = false;
        public void MemoryRead()
        {
            if (MemoryIsFull)
            {
                CurrentState = State.Answer;
                CurrNumber = Buffer = MemoryCell;
            }
        }
        public void MemoryWrite()
        {
            MemoryCell = (CurrentState == State.Answer) 
                ? Accumulator : CurrNumber;
            MemoryIsFull = true;
        }
        public void MemoryClear()
        {
            MemoryCell = 0.0;
            MemoryIsFull = false;
        }
        public void MemoryPlus()
        {
            if (MemoryIsFull)
                MemoryCell += CurrNumber;
        }
        public void MemoryMinus()
        {
            if (MemoryIsFull)
                MemoryCell -= CurrNumber;
        }
    }
}
