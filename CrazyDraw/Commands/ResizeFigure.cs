using CrazyDraw.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDraw.Commands
{
    class ResizeFigure : ICommand
    {
        float oldX;
        float oldY;
        float newX;
        float newY;
        IFigure figure;

        public ResizeFigure(float oldX, float oldY, float newX, float newY, IFigure figure) {
            this.oldX = oldX;
            this.oldY = oldY;
            this.newX = newX;
            this.newY = newY;
            this.figure = figure;
        }
        public void Do(){ figure.Resize(newX, newY); }
        public void Undo() { figure.Resize(oldX, oldY); }
    }
}
