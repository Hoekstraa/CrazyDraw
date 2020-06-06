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

        string north = "";
        string south = "";
        string east = "";
        string west = "";

        public DecoratedFigure(IFigure figure) { this.figure = figure; }
        public void Update() { }

        public void Draw()
        {
            figure.Draw();
            DrawTextRec(GetFontDefault(), south,
                new Rectangle(figure.Size().x,figure.Size().y + 50, figure.Size().width,figure.Size().height),
			    20, 1, true, BLACK);
            DrawTextRec(GetFontDefault(), north,
                new Rectangle(figure.Size().x, figure.Size().y - 20, figure.Size().width, figure.Size().height ),
                20, 1, true, BLACK);
                DrawTextRec(GetFontDefault(), west,
                new Rectangle(figure.Size().x-40, figure.Size().y, figure.Size().width, figure.Size().height),
                20, 1, true, BLACK);
                DrawTextRec(GetFontDefault(), east,
                new Rectangle(figure.Size().x, figure.Size().y, figure.Size().width, figure.Size().height),
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
        public void setSouth(string South) 
        {
            south = South;
            figure.Size();

        }
        public void setWest(string West)
        {
            west = West;
        }
        public void setEast(string East)
        {
            east = East;
        }
        public void setNorth(string North)
        {
            north = North;
        }


        public bool Collide(Vector2 point) { Console.WriteLine("Placeholder hit"); return false; }
        public Rectangle Size() { return new Rectangle(0, 0, 0, 0); }

        public void Resize(float x, float y) { Console.WriteLine("Resize DecoratedFigure hit"); }
        public void Move(float x, float y) { Console.WriteLine("Move DecoratedFigure hit"); }

    }
}
