using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace CrazyDraw.Figures
{
    partial class BasicFigure
    {
        public sealed class RectangleStrategy : Strategy
        {
            private static readonly RectangleStrategy instance = new RectangleStrategy();

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static RectangleStrategy()
            {
            }

            private RectangleStrategy()
            {
            }

            public static RectangleStrategy Instance
            {
                get
                {
                    return instance;
                }
            }
            public bool Collide(float x, float y, float width, float height, Vector2 point)
            {
                return CheckCollisionPointRec(point, new Rectangle(x, y, width, height))
                    && !CheckCollisionPointRec(
                            point,
                            new Rectangle(x + width - Global.MOUSE_SCALE_MARK_SIZE,
                                y + height - Global.MOUSE_SCALE_MARK_SIZE,
                                Global.MOUSE_SCALE_MARK_SIZE,
                                Global.MOUSE_SCALE_MARK_SIZE));
            }
            public void Draw(float posX, float posY, float width, float height, Color color, bool selected, bool mouseScaleReady)
            {
                Rectangle rec = new Rectangle(posX, posY, width, height);
                if (selected)
                    DrawRectangleRec(rec, RED);
                else
                    DrawRectangleRec(rec, color);

                if (mouseScaleReady)
                {
                    DrawRectangleLinesEx(rec, 1, BLACK);
                    DrawTriangle(
                            new Vector2(
                                rec.x + rec.width - Global.MOUSE_SCALE_MARK_SIZE,
                                rec.y + rec.height),
                            new Vector2(rec.x + rec.width, rec.y + rec.height),
                            new Vector2(rec.x + rec.width,
                                rec.y + rec.height - Global.MOUSE_SCALE_MARK_SIZE), BLACK);
                }
            }
            public string ToString(float indents, float x, float y, float width, float height) { return ""; }


        }
    }
}
