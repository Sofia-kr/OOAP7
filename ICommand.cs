using System;
using System.Collections.Generic;
using System.Text;

namespace OOAPLAB7
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

}
