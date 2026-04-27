using System;
using System.Collections.Generic;
using System.Text;

namespace OOAPLAB7
{
    public class Invoker
    {
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); // після нової команди redo стає недоступним
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                ICommand command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
            }
            else
            {
                Console.WriteLine("Нічого скасовувати.");
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                ICommand command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
            else
            {
                Console.WriteLine("Нічого повторювати.");
            }
        }
    }
}
