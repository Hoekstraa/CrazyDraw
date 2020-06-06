using System;
using System.Collections.Generic;
using System.Text;
using CrazyDraw.Canvas;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.MouseButton;
using Raylib_cs;
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
                if (IsMouseButtonDown(MOUSE_LEFT_BUTTON)
                    && f.Collide(GetMousePosition())
                    && f.mousePositionLastFrame.X != GetMousePosition().X
                    && f.mousePositionLastFrame.Y != GetMousePosition().Y
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

            public void Visit(Group group) { }

            public void Visit(DecoratedFigure f) { }
        }
    }
}
