using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace CrazyDraw.Figures
{
    class BasicFigure : Figure
    {   
        public void Update() { }
        public void Draw() { }
        public int UID() { return 1; }
        public Rectangle Size() { return new Rectangle(0, 0, 0, 0); }

    }
}
