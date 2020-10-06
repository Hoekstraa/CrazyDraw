using Raylib_cs;
using System.Numerics;

namespace CrazyDraw.Figures
{
    partial interface IFigure
    {
        public void Update();
        public void Draw();
        public void Accept(IVisitor visitor);
        public int UID();
        public bool Collide(Vector2 point);
        public Rectangle Size();
        public void Resize(float x, float y);
        public void Move(float x, float y);
    }
}
