using CrazyDraw.Canvas;
using CrazyDraw.Figures;
using System.Collections.Generic;

namespace CrazyDraw.Commands
{
    class GroupFigures : ICommand
    {
        CanvasManager cManager;
        Group group = new Group();
        public GroupFigures(CanvasManager canvasManager, List<IFigure> figures) {
            cManager = canvasManager;
            foreach(var fig in figures)
                group.figures.Add(fig);
        }
        public void Do() {
            foreach(var fig in group.figures)
                cManager.canvas.RemoveFigure(fig);
            cManager.canvas.AddFigure(group);
        }
        public void Undo() {
            foreach(var fig in group.figures)
                cManager.canvas.AddFigure(fig);
            cManager.canvas.RemoveFigure(group);
        }
    }
}
