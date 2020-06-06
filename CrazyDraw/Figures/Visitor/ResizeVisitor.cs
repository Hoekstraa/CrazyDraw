using CrazyDraw.Canvas;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.MouseButton;
using Raylib_cs;

namespace CrazyDraw.Figures
{
    partial interface IFigure
    {
        internal class ResizeVisitor : IVisitor
        {
            CanvasManager canvasManager;
            public ResizeVisitor(CanvasManager canvasManager) { this.canvasManager = canvasManager; }
            public void Visit(BasicFigure f)
            {
                Vector2 mouse = GetMousePosition();
                Rectangle rec = new Rectangle(f.posX, f.posY, f.width, f.height);

                if (CheckCollisionPointRec
                    (mouse,
                    new Rectangle(rec.x + rec.width - Global.MOUSE_SCALE_MARK_SIZE,
                    rec.y + rec.height - Global.MOUSE_SCALE_MARK_SIZE,
                    Global.MOUSE_SCALE_MARK_SIZE, Global.MOUSE_SCALE_MARK_SIZE)))
                {
                    f.mouseScaleReady = true;
                    if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
                    {
                        f.mouseScaleMode = true;
                        f.OldWidth = f.width;
                        f.OldHeight = f.height;
                    }
                }
                else f.mouseScaleReady = false;

                if (f.mouseScaleMode)
                {
                    f.mouseScaleReady = true;
                    f.width = mouse.X - f.posX;
                    f.height = mouse.Y - f.posY;

                    if (f.width < Global.MOUSE_SCALE_MARK_SIZE)
                        f.width = Global.MOUSE_SCALE_MARK_SIZE;
                    if (f.height < Global.MOUSE_SCALE_MARK_SIZE)
                        f.height = Global.MOUSE_SCALE_MARK_SIZE;
                    if (IsMouseButtonReleased(MOUSE_LEFT_BUTTON))
                    {
                        f.mouseScaleMode = false;
                        canvasManager.Do(new Commands.ResizeFigure(f.OldWidth,f.OldHeight,f.width,f.height, f));
                    }
                }
            }
            public void Visit(Group g)
            {
                Vector2 mouse = GetMousePosition();

                var s = g.Size();

                if (CheckCollisionPointRec
                (mouse,
                 new Rectangle(
                    s.x + s.width - Global.MOUSE_SCALE_MARK_SIZE,
                    s.y + s.height - Global.MOUSE_SCALE_MARK_SIZE,
                    Global.MOUSE_SCALE_MARK_SIZE, Global.MOUSE_SCALE_MARK_SIZE
                )))
                {
                    g.mouseScaleReady = true;
                    if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON)) g.mouseScaleMode = true;
                }
                else g.mouseScaleReady = false;

                if (g.mouseScaleMode)
                {
                    g.mouseScaleReady = true;
                    //g->Size().width = (mouse.x - g->Size().x);
                    //g->Size().height = (mouse.y - g->Size().y);

                    if (s.width < Global.MOUSE_SCALE_MARK_SIZE)
                        ;
                    //s->width = MOUSE_SCALE_MARK_SIZE;
                    if (s.height < Global.MOUSE_SCALE_MARK_SIZE)
                        ;
                    //s->height = MOUSE_SCALE_MARK_SIZE;
                    if (IsMouseButtonReleased(MOUSE_LEFT_BUTTON))
                        g.mouseScaleMode = false;
                }
            }

            public void Visit(DecoratedFigure f) { }
        }
    }
}
