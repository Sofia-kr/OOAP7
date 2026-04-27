using System;
using System.Collections.Generic;
using System.Text;

namespace OOAPLAB7
{
    public class Calculator
    {
        public double CurrentValue { get; set; }

        public void Add(double value)
        {
            CurrentValue += value;
        }

        public void Subtract(double value)
        {
            CurrentValue -= value;
        }

        public void Multiply(double value)
        {
            CurrentValue *= value;
        }

        public void Divide(double value)
        {
            if (value != 0)
                CurrentValue /= value;
            else
                throw new DivideByZeroException("Ділення на нуль!");
        }
    }
}
