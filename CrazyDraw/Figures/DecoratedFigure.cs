using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace CrazyDraw.Figures
{
    class DecoratedFigure : IFigure
    {
        IFigure figure;

        string north = "Hallo";
        string south = "";
        string east = "";
        string west = "";

        public DecoratedFigure(IFigure figure) { this.figure = figure; }
        public void Update() { }

        public void Draw()
        {
            figure.Draw();
            DrawTextRec(GetFontDefault(), north,
                new Rectangle(figure.Size().x,figure.Size().y,figure.Size().width,figure.Size().height),
			    20, 1, true, BLACK);
            //DrawText(north, );
            //DrawText(south, );
            //...
        }
        public int UID() { return 1; }
        public void Accept(IFigure.IVisitor visitor)
        {
            visitor.Visit(this);
        }


        public bool Collide(Vector2 point) { Console.WriteLine("Placeholder hit"); return false; }
        public Rectangle Size() { return new Rectangle(0, 0, 0, 0); }

        public void Resize(float x, float y) { Console.WriteLine("Resize DecoratedFigure hit"); }
        public void Move(float x, float y) { Console.WriteLine("Move DecoratedFigure hit"); }

    }
}
