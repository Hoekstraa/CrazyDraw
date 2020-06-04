using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace CrazyDraw.Figures
{
    interface Figure
    {
        public void Update();
        public void Draw();
        public int UID();
        public Rectangle Size();
    }
}
