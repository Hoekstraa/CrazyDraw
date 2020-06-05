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
            public MoveVisitor(CanvasManager canvasManager) { }
        }
    }
}
