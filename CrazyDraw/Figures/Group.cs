using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;
using System;
using System.Collections.Generic;

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
        public void Accept(IFigure.IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public int UID() { return 1; }
        public bool Collide(Vector2 point) { Console.WriteLine("Group Collide() placeholder hit"); return false; }
        public Rectangle Size() { return new Rectangle(0, 0, 0, 0); }

        public void Resize(float x, float y){Console.WriteLine("Resize Group hit");}
        public void Move(float x, float y){Console.WriteLine("Move Group hit");}

        public List<IFigure> figures;
    }
}
