using CrazyDraw.Canvas;
using CrazyDraw.Figures;

namespace CrazyDraw.Commands
{
    class AddOrnament : ICommand
    {
        Canvas.Canvas canvas;
        DecoratedFigure decFigure;
        public AddOrnament(CanvasManager canvasManager, IFigure figure, string n, string e, string s, string w)
        {
            canvas = canvasManager.canvas;
            decFigure = new DecoratedFigure(figure);
            decFigure.North(n);
            decFigure.East(e);
            decFigure.South(s);
            decFigure.West(w);
        }
        public void Do()
        {
            canvas.RemoveFigure(decFigure.figure);
            canvas.AddFigure(decFigure);
        }
        public void Undo()
        {
            canvas.RemoveFigure(decFigure);
            canvas.AddFigure(decFigure.figure);
        }
    }
}
