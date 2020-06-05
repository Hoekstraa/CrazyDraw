using CrazyDraw.Canvas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDraw.Figures{

    partial interface IFigure
    {
        internal class ResizeVisitor : IVisitor
        {
            public ResizeVisitor(CanvasManager canvasManager) { }

        }

    }
}
