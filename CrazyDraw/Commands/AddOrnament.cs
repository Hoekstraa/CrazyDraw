using System;
using CrazyDraw.Canvas;
using CrazyDraw.Figures;
using System.Collections.Generic;

namespace CrazyDraw.Commands
{
    class AddOrnament : ICommand
    {
        Canvas.Canvas canvas;
        List<DecoratedFigure> decFigures = new List<DecoratedFigure>();
        public AddOrnament(CanvasManager canvasManager, List<IFigure> figures)
        {
            canvas = canvasManager.canvas;

            foreach(var fig in figures)
            {
                DecoratedFigure df = fig is DecoratedFigure? (DecoratedFigure)fig : new DecoratedFigure(fig);
                
                Console.WriteLine("What direction of figure " + fig.ToString() + " do you want to add an ornament?");
                string dir = Console.ReadLine();

                Console.WriteLine("What do you want to write here?");
                string input = Console.ReadLine();

                if(dir == "north" || dir == "up" || dir == "top")
                    df.North(input);
                if(dir == "east" || dir == "right")
                    df.East(input);
                if(dir == "south" || dir == "down" || dir == "bottom")
                    df.South(input);
                if(dir == "west" || dir == "left")
                    df.West(input);
                decFigures.Add(df);
            }
        }
        public void Do()
        {
            foreach(var fig in decFigures)
            {
                canvas.RemoveFigure(fig.figure);
                canvas.AddFigure(fig);
            }
        }
        public void Undo()
        {
            foreach(var fig in decFigures)
            {
                canvas.RemoveFigure(fig);
                canvas.AddFigure(fig.figure);
            }
        }
    }
}
