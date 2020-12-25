using System.Collections.Generic;
using CrazyDraw.Commands;
using System.Linq;

namespace CrazyDraw.Canvas
{
    class CanvasManager
    {
        public Canvas canvas = new Canvas();

        public CanvasManager() { }
        public void Add(ICommand c) { commands.Add(c); }
        public void Do(ICommand c) { c.Do(); commands.Add(c); }
        public void Undo()
        {
            if (commands.Count > 0)
            {
                var c = commands.Last();
                commands.RemoveAt(commands.Count - 1);
                c.Undo();
                undoneCommands.Add(c);
            }
        }

        public void Redo()
        {
            if (undoneCommands.Count > 0)
            {
                var c = undoneCommands.Last();
                undoneCommands.RemoveAt(undoneCommands.Count - 1);
                c.Do();
                commands.Add(c);
            }
        }

        List<ICommand> commands = new List<ICommand>();
        List<ICommand> undoneCommands = new List<ICommand>();

    }
}
