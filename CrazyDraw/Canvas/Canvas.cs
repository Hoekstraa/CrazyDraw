using System.Collections.Generic;
using CrazyDraw.Figures;
using System.Linq;
using static Raylib_cs.Raylib;
using static Raylib_cs.MouseButton;

namespace CrazyDraw.Canvas
{
    class Canvas
    {
        public void Update() {
            if (selecting)
                SelectFigures();
        }

        public void Visit(IFigure.IVisitor visitor) {
            if (!selecting)
                foreach (var fig in figures)
                    fig.Accept(visitor);
        }

        public void Draw() {
            foreach(var fig in figures)
                fig.Draw();
        }

        public void AddFigure(IFigure figure) { figures.Add(figure); }
        public void RemoveFigure(IFigure figure) { figures.RemoveAll((IFigure f) => f.UID() == figure.UID()); }

        public void SelectFigures() {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
                foreach(var fig in Enumerable.Reverse(figures))
                    if(fig.Collide(GetMousePosition()))
                    {
                        selectedFigures.Add(fig);
                        break;
                    }
        }

        public List<IFigure> figures = new List<IFigure>();
        public bool selecting = false;
        public List<IFigure> selectedFigures = new List<IFigure>();
    }
}
