using CrazyDraw.Figures;

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
        public void Do()
        {
            if(figure is Group)
                figure.RelMove(newX - oldX, newY - oldY);//relative move
            else
                figure.Move(newX, newY);
        }
        public void Undo()
        {
            if(figure is Group)
                figure.RelMove(oldX - newX, oldY - newX);//relative move
            else
                figure.Move(oldX, oldY);
        }
    }
}
