using System;
using System.Collections.Generic;
using System.Text;
using CrazyDraw.Figures;

namespace CrazyDraw.Canvas
{
    class Canvas
    {
        public void Update() { }
        public void Visit(IFigure.IVisitor visitor) {
        
        }

        public void Draw() { 
            foreach(var fig in figures)
                fig.Draw();
        }
        public void AddFigure(IFigure figure) { figures.Add(figure); }
        public void removeFigure() { }
        public void GroupSelected() { }

        List<IFigure> figures = new List<IFigure>();
    }
}
