using CrazyDraw.Canvas;
using static Raylib_cs.Raylib;
using static Raylib_cs.MouseButton;
using CrazyDraw.Commands;

namespace CrazyDraw.Figures
{
    partial interface IFigure
    {
        internal class MoveVisitor : IVisitor
        {
            CanvasManager canvasManager;
            public MoveVisitor(CanvasManager canvasManager) { this.canvasManager = canvasManager; }

            public void Visit(BasicFigure f)
            {
                if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON)
                        && f.Collide(GetMousePosition())
                   )
                {
                    f.OldX = f.posX;
                    f.OldY = f.posY;
                    f.mouseMoveMode = true;
                }
                if(f.mouseMoveMode)
                {
                    f.posX += (GetMousePosition().X - f.mousePositionLastFrame.X);
                    f.posY += (GetMousePosition().Y - f.mousePositionLastFrame.Y);
                }

                if (IsMouseButtonReleased(MOUSE_LEFT_BUTTON) && f.mouseMoveMode == true)
                {
                    canvasManager.Do(new MoveFigure(f.OldX, f.OldY, f.posX, f.posY, f));
                    f.mouseMoveMode = false;
                }

                f.mousePositionLastFrame = GetMousePosition();
            }

            public void Visit(Group f)
            {
                if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON)
                        && f.Collide(GetMousePosition())
                   )
                {
                    f.OldX = f.Size().x;
                    f.OldY = f.Size().y;
                    f.mouseMoveMode = true;
                }

                if(f.mouseMoveMode)
                    f.RelMove(GetMousePosition().X - f.mousePositionLastFrame.X, GetMousePosition().Y - f.mousePositionLastFrame.Y);

                if (IsMouseButtonReleased(MOUSE_LEFT_BUTTON) && f.mouseMoveMode == true)
                {
                    canvasManager.Add(new MoveFigure(f.OldX, f.OldY, f.Size().x, f.Size().y, f));
                    f.mouseMoveMode = false;
                }

                f.mousePositionLastFrame = GetMousePosition();
            }

            public void Visit(DecoratedFigure f) {}
        }
    }
}
