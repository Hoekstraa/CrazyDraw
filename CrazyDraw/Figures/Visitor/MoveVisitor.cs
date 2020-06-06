using System;
using System.Collections.Generic;
using System.Text;
using CrazyDraw.Canvas;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.MouseButton;
using Raylib_cs;

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
                    f.mouseMoveMode = true;
                }
                if (IsMouseButtonReleased(MOUSE_LEFT_BUTTON))
                    f.mouseMoveMode = false;

                if(f.mouseMoveMode)
                {
                    f.posX = f.posX + (GetMousePosition().X - f.mousePositionLastFrame.X);
                    f.posY = f.posY + (GetMousePosition().Y - f.mousePositionLastFrame.Y);
                }

                f.mousePositionLastFrame = GetMousePosition();
            }

            public void Visit(Group group) { }
        }
    }
}
