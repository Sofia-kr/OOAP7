using System;
using System.Collections.Generic;
using System.Text;

namespace OOAPLAB7
{
    public class SubtractCommand : ICommand
    {
        private readonly Calculator _calculator;
        private readonly double _value;
        private double _previousValue;

        public SubtractCommand(Calculator calculator, double value)
        {
            _calculator = calculator;
            _value = value;
        }

        public void Execute()
        {
            _previousValue = _calculator.CurrentValue;
            _calculator.Subtract(_value);
        }

        public void Undo()
        {
            _calculator.CurrentValue = _previousValue;
        }
    }
}
