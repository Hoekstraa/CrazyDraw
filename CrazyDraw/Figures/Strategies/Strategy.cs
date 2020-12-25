using Raylib_cs;
using System.Numerics;

namespace CrazyDraw.Figures
{
    partial class BasicFigure
    {
        internal interface Strategy
        {
            bool Collide(float x, float y, float width, float height, Vector2 point);
            void Draw(float posX, float posY, float width, float height, Color color, bool selected, bool mouseScaleReady);
            string ToString(float indents, float x, float y, float width, float height);
        }
    }
}
