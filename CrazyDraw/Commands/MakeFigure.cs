using CrazyDraw.Canvas;
using CrazyDraw.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDraw.Commands
{
    class MakeFigure : ICommand
    {
        CanvasManager canvasManager;
        IFigure figure;
        public MakeFigure(CanvasManager canvasManager, IFigure figure) { this.canvasManager = canvasManager; this.figure = figure; }
        public void Do() { canvasManager.canvas.AddFigure(figure); }
        public void Undo() { canvasManager.canvas.RemoveFigure(figure); }
    }
}
