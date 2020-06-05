using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.KeyboardKey;
using static Raylib_cs.MouseButton;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using CrazyDraw.Canvas;

namespace CrazyDraw
{
    class ButtonCollection
    {
        internal class Button
        {
            Color color = BLUE;
            float x;
            float y;
            string text;
            Func<bool> function; 

            void Draw()
            {
                DrawRectangleLinesEx(new Rectangle(x,y,(float)MeasureText(text,20) + 6, 24), 2, color);
                DrawText(text, (int)x + 3, (int)y + 1, 20, color);
            }

            void Update()
            {
                if (CheckCollisionPointRec(GetMousePosition(), new Rectangle(x, y, (float)MeasureText(text, 20) + 6, 24))
                    && IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
                    function();
            }
        }

        List<Button> buttons;

        public ButtonCollection(CanvasManager canvasManager) { }
        public void Draw() { }
        public void Update() { }

    }
}
