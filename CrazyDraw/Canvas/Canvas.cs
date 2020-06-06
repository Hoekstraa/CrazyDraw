using System;
using System.Collections.Generic;
using System.Text;
using CrazyDraw.Figures;

namespace CrazyDraw.Canvas
{
    class Canvas
    {
        public void Update() {
            foreach (var fig in figures)
                fig.Update();
        }

        public void Visit(IFigure.IVisitor visitor) {
            foreach (var fig in figures)
                visitor.Visit((BasicFigure)fig);
        }

        public void Draw() { 
            foreach(var fig in figures)
                fig.Draw();
        }
        public void AddFigure(IFigure figure) { figures.Add(figure); }
        public void RemoveFigure(IFigure figure) { figures.RemoveAll((IFigure f) => f.UID() == figure.UID()); }
        public void GroupSelected() { }

        List<IFigure> figures = new List<IFigure>();
    }
}
