using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System;
using System.Numerics;

namespace CrazyDraw.Figures
{
    class DecoratedFigure : IFigure
    {
        IFigure figure;
        public DecoratedFigure(IFigure figure) { this.figure = figure; }
        public void Update() { }
        public void Draw() { }
        public int UID() { return 1; }

        public bool Collide(Vector2 point) { Console.WriteLine("Placeholder hit"); return false; }
        public Rectangle Size() { return new Rectangle(0, 0, 0, 0); }

        public void Resize(float x, float y){Console.WriteLine("Resize DecoratedFigure hit");}
        public void Move(float x, float y){Console.WriteLine("Move DecoratedFigure hit");}

    }
}
