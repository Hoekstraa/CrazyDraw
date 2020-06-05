using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace CrazyDraw.Figures
{
    partial interface IFigure
    {
        public void Update();
        public void Draw();
        public int UID();
        public Rectangle Size();
    }
}
