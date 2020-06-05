using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;

namespace CrazyDraw.Figures
{
    class Group : IFigure
    {
        internal bool mouseScaleReady = false;
        internal bool mouseScaleMode = false;
        internal bool selected = false;
        internal bool mouseMoveMode = false;
        internal Vector2 mousePositionLastFrame = new Vector2(0, 0);

        public void Update() { }
        public void Draw() { }
        public int UID() { return 1; }
        public Rectangle Size() { return new Rectangle(0, 0, 0, 0); }

    }
}
