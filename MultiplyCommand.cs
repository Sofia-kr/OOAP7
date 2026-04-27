using System;
using System.Collections.Generic;
using System.Text;

namespace OOAPLAB7
{
    public class MultiplyCommand : ICommand
    {
        private readonly Calculator _calculator;
        private readonly double _value;
        private double _previousValue;

        public MultiplyCommand(Calculator calculator, double value)
        {
            _calculator = calculator;
            _value = value;
        }

        public void Execute()
        {
            _previousValue = _calculator.CurrentValue;
            _calculator.Multiply(_value);
        }

        public void Undo()
        {
            _calculator.CurrentValue = _previousValue;
        }
    }
}
