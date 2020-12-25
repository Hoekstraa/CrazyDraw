using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace CrazyDraw.Figures
{
    partial class BasicFigure
    {
        public sealed class EllipseStrategy : Strategy
        {
            private static readonly EllipseStrategy instance = new EllipseStrategy();

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static EllipseStrategy()
            {
            }

            private EllipseStrategy()
            {
            }

            public static EllipseStrategy Instance
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
                if (selected)
                    DrawEllipse((int)(posX + 0.5 * width), (int)(posY + 0.5 * height), (float)(0.5 * width), (float)(0.5 * height), RED);
                else
                    DrawEllipse((int)(posX + 0.5 * width), (int)(posY + 0.5 * height), (float)(0.5 * width), (float)(0.5 * height), BLUE);

                if (mouseScaleReady)
                {
                    Rectangle rec = new Rectangle(posX, posY, width, height);
                    DrawRectangleLinesEx(rec, 1, BLACK);
                    DrawTriangle(new Vector2(
                        rec.x + rec.width - Global.MOUSE_SCALE_MARK_SIZE,
                       rec.y + rec.height),
    new Vector2(rec.x + rec.width, rec.y + rec.height),
        new Vector2(rec.x + rec.width,
                  rec.y + rec.height - Global.MOUSE_SCALE_MARK_SIZE),
        BLACK);
                }
            }

            public string ToString(float indents, float x, float y, float width, float height)
            {
                string indent = "";

                for(int i = 0; i < indents; i++)
                    indent += "\t";

                return indent + "ellipse " + x + " " + y + " " + width + " " + height + "\n";
            }

        }
    }
}
