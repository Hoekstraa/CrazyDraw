using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CrazyDraw.Canvas
{
    class CanvasManager
    {
        public Canvas canvas = new Canvas();

        public CanvasManager() { }
        public void Do() { }
        public void Undo(){ }
        public void Redo() { }

        //List<Command> commands;
        //List<Command> undoneCommands;

    }
}
