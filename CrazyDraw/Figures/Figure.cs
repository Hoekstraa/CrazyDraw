using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;

namespace CrazyDraw.Figures
{
    partial interface IFigure
    {
        public void Update();
        public void Draw();
        public int UID();
        public bool Collide(Vector2 point);
        public Rectangle Size();
        public void Resize(float x, float y);
    }
}
