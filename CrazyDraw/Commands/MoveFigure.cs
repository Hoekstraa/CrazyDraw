using CrazyDraw.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDraw.Commands
{
    class MoveFigure : ICommand
    {
        float oldX;
        float oldY;
        float newX;
        float newY;
        IFigure figure;

        public MoveFigure(float oldX, float oldY, 
                          float newX, float newY,IFigure figure)
        {
            this.oldX = oldX;
            this.oldY = oldY;
            this.newX = newX;
            this.newY = newY;
            this.figure = figure;
        }
        public void Do() { figure.Move(newX, newY); }
        public void Undo() { figure.Move(oldX, oldY); }
    }
}
