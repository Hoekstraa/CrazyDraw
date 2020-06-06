using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDraw.Commands
{
    interface ICommand
    {
        void Do();
        void Undo();
    }
}
