using System;
using System.Collections.Generic;
using System.Text;
using CrazyDraw.Figures;

namespace CrazyDraw.Canvas
{
    class Canvas
    {
        public void Update() { }
        public void Visit(IFigure.IVisitor visitor) { }
        public void Draw() { }
        public void AddFigure() { }
        public void removeFigure() { }
        public void GroupSelected() { }

        List<CrazyDraw.Figures.IFigure> figures;
    }
}
