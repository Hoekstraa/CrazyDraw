using Raylib_cs;
using static Raylib_cs.Raylib;
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

        public void Update() {
            foreach(IFigure f in figures)
                f.Update();
        }
        public void Draw() {
            foreach(IFigure f in figures)
                f.Draw();
        }
        public void Accept(IFigure.IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public int UID() {return 1;}
        public bool Collide(Vector2 point)
        {
            return CheckCollisionPointRec(point, new Rectangle(Size().x, Size().y, Size().width,Size().height))
                && !CheckCollisionPointRec(
                        point,
                        new Rectangle(Size().x + Size().width - Global.MOUSE_SCALE_MARK_SIZE,
                            Size().y + Size().height - Global.MOUSE_SCALE_MARK_SIZE,
                            Global.MOUSE_SCALE_MARK_SIZE,
                            Global.MOUSE_SCALE_MARK_SIZE));
        }
        public Rectangle Size() {
            float x = 99999999999;
            float y = 99999999999;
            float botX = -1;
            float botY = -1;

            foreach(IFigure f in figures)
            {
                var fs = f.Size();
                if(fs.x < x) x = fs.x;
                if(fs.y < y) y = fs.y;

                if(fs.x +fs.width > botX) botX = fs.x + fs.width;
                if(fs.y +fs.height > botY) botY = fs.y + fs.height;
            }
            return new Rectangle(x, y, botX - x, botY - y);
        }

        public void Resize(float x, float y){Console.WriteLine("Resize Group hit");}
        public void Move(float x, float y){Console.WriteLine("Move Group hit");}

        public List<IFigure> figures = new List<IFigure>();
    }
}
