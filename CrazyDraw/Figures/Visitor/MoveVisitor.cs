using System;
using System.Collections.Generic;
using System.Text;
using CrazyDraw.Canvas;

namespace CrazyDraw.Figures
{
    partial interface IFigure
    {
        internal class MoveVisitor : IVisitor
        {
            CanvasManager canvasManager;
            public MoveVisitor(CanvasManager canvasManager) { this.canvasManager = canvasManager; }
            public void Visit(BasicFigure basicFigure) { }
            public void Visit(Group group) { }
        }
    }
}
