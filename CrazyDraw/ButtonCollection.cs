using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.KeyboardKey;
using static Raylib_cs.MouseButton;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using CrazyDraw.Canvas;
using System.Reflection.Metadata.Ecma335;

namespace CrazyDraw
{
    class ButtonCollection
    {
        internal class Button
        {
            Color color = GRAY;
            int x;
            int y;
            string text;
            Func<bool> function;

            public Button(int x, int y, string text, Func<bool> func) { this.x = x; this.y = y; this.text = text; this.function = func; }

            public void Draw()
            {
                DrawRectangleLinesEx(new Rectangle(x, y, (float)MeasureText(text, 20) + 6, 24), 2, color);
                DrawText(text, x + 3, y + 1, 20, color);
            }

            public void Update()
            {
                if (CheckCollisionPointRec(GetMousePosition(), new Rectangle(x, y, (float)MeasureText(text, 20) + 6, 24))
                    && IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
                    function();
            }
        }

        List<Button> buttons = new List<Button>();

        public ButtonCollection(CanvasManager canvasManager)
        {
            buttons.Add(new Button(10, 10, "Hello", () =>
            {
                Console.WriteLine("Button pressed!");
                return true;
            }));
        }
        public void Draw() { foreach (var b in buttons) b.Draw(); }
        public void Update() { foreach (var b in buttons) b.Update(); }

    }
}
