using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDraw.Canvas
{
    class Canvas
    {
        public void Update() { }
        public void Visit() { }
        public void Draw() { }
        public void AddFigure() { }
        public void removeFigure() { }
        public void GroupSelected() { }

        List<CrazyDraw.Figures.Figure> figures;
    }
}
