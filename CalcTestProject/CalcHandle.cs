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
        private const int MAX_DIGITS = 18;
        private const int MAX_DIGITS_AFTER_COMMA = 9;

        public string ActiveVariable { get; private set; } = "0";
        public string PassiveVariable { get; private set; } = "0";
        public string Answer { get; private set; } = "0";

        //Состояния калькулятора
        private enum State
        {
            N, Addition, Subtraction, Multiplication, Division, Error
        }
        private State CurrentState = State.N;
        public bool IsNotBusy()
        {
            return CurrentState == State.N;
        }
        public bool IsError()
        {
            return CurrentState == State.Error;
        }

        public bool CanEqual { get; private set; } = false;
        public bool IsPercent { get; private set; } = false;

        //Методы обработки чисел
        public void AddDigit(string Num)
        {
            if (CurrentState == State.Error)
            {
                CurrentState = State.N;
            }
            if (ActiveVariable.Length <= MAX_DIGITS)
            {
                if (ActiveVariable.Length > 0 && ActiveVariable[0] == '0' 
                    && !ActiveVariable.Contains(","))
                {
                    ActiveVariable = Num;
                }
                else
                {
                    ActiveVariable += Num;
                }
            }
        }
        public void SetNumber(string Num)
        {
            if (CurrentState == State.Error)
            {
                CurrentState = State.N;
            }
            ActiveVariable = Num;
        }

        public void AddComma()
        {
            if (ActiveVariable.Length <= MAX_DIGITS && !ActiveVariable.Contains(","))
            {
                ActiveVariable += ",";
            }
        }

        public void RemoveDigit()
        {
            if (CurrentState == State.Error)
            {
                CurrentState = State.N;
            }
            if (ActiveVariable.Length > 1)
            {
                ActiveVariable = ActiveVariable.Remove(ActiveVariable.Length - 1, 1);
            }
            else if (ActiveVariable.Length == 1)
            {
                ActiveVariable = "0";
            }
        }
        public void Remove_CE()
        {
            if (CurrentState == State.Error)
            {
                CurrentState = State.N;
            }
            ActiveVariable = "0";
            CurrentState = State.N;
        }
        public void Remove_C()
        {
            CurrentState = State.N;
            ActiveVariable = "0";
        }

        public void Addition()
        {
            if (CurrentState == State.N)
            {
                PassiveVariable = ActiveVariable;
                ActiveVariable = "0";
                CurrentState = State.Addition;
                CanEqual = true;
            }
        }
        public void Subtraction()
        {
            if (CurrentState == State.N)
            {
                PassiveVariable = ActiveVariable;
                ActiveVariable = "0";
                CurrentState = State.Subtraction;
                CanEqual = true;
            }
        }
        public void Multiplication()
        {
            if (CurrentState == State.N)
            {
                PassiveVariable = ActiveVariable;
                ActiveVariable = "0";
                CurrentState = State.Multiplication;
                CanEqual = true;
            }
        }
        public void Division()
        {
            if (CurrentState == State.N)
            {
                PassiveVariable = ActiveVariable;
                ActiveVariable = "0";
                CurrentState = State.Division;
                CanEqual = true;
            }
        }

        //История операций
        public ObservableCollection<string> CalcHistory { get; private set; } 
            = new ObservableCollection<string>();

        public void Equals()
        {
            if (CanEqual)
            {
                double X = Convert.ToDouble(ActiveVariable);
                double Y = Convert.ToDouble(PassiveVariable);

                if (CurrentState == State.Addition)
                {
                    if (IsPercent)
                        X = Y / 100 * X;
                    Answer = Convert.ToString(Math.Round(Y + X, MAX_DIGITS_AFTER_COMMA));
                }

                if (CurrentState == State.Subtraction)
                {
                    if (IsPercent)
                        X = Y / 100 * X;
                    Answer = Convert.ToString(Math.Round(Y - X, MAX_DIGITS_AFTER_COMMA));
                }

                if (CurrentState == State.Multiplication)
                {
                    if (IsPercent)
                        X = Y / 100;
                    Answer = Convert.ToString(Math.Round(Y * X, MAX_DIGITS_AFTER_COMMA));
                }

                if (CurrentState == State.Division)
                {
                    if (IsPercent)
                        X = Y / 100;
                    Answer = Convert.ToString(Math.Round(Y / X, MAX_DIGITS_AFTER_COMMA));
                }

                CurrentState = State.N;
                CanEqual = false; IsPercent = false;

                ActiveVariable = Answer;
                PassiveVariable = "0";

                CalcHistory.Add(ActiveVariable);
            }
        }

        public void SignSwitch()
        {
            double Number = Convert.ToDouble(ActiveVariable);
            if (Number > 0)
            {
                ActiveVariable = ActiveVariable.Insert(0, "-");
            }
            if (Number < 0)
            {
                ActiveVariable = ActiveVariable.Remove(0, 1);
            }
        }
        public void Sqrt()
        {
            double X = Convert.ToDouble(ActiveVariable);
            if (X < 0)
            {
                ActiveVariable = "0";
                CurrentState = State.Error;
            }
            else
            {
                ActiveVariable = Convert.ToString(Math.Round(Math.Sqrt(X), MAX_DIGITS_AFTER_COMMA));
                CalcHistory.Add(ActiveVariable);
            }    
        }
        public void Reverse()
        {
            double X = Convert.ToDouble(ActiveVariable);
            ActiveVariable = Convert.ToString(Math.Round(1 / X, MAX_DIGITS_AFTER_COMMA));
            CalcHistory.Add(ActiveVariable);
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
                ActiveVariable = MemoryCell;
            }
        }
        public void MemoryWrite()
        {
            MemoryCell = ActiveVariable;
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
                    Convert.ToDouble(MemoryCell) + Convert.ToDouble(ActiveVariable));
            }
        }
        public void MemoryMinus()
        {
            if (CurrentMemoryState == MemoryState.IsFull)
            {
                MemoryCell = Convert.ToString(
                    Convert.ToDouble(MemoryCell) - Convert.ToDouble(ActiveVariable));
            }
        }
    }
}
