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
        public float OldX;
        public float OldY;
        internal bool mouseScaleReady = false;
        internal bool mouseScaleMode = false;
        internal bool selected = false;
        internal bool mouseMoveMode = false;
        internal Vector2 mousePositionLastFrame = new Vector2(0, 0);
        int uid;

        public Group(){uid = Global.UniqueId++;}

        public string ToString(int indent)
        {
            return "not complete! (Group)";
        }

        public void Draw() {
            foreach(IFigure f in figures)
                f.Draw();
            DrawRectangleLinesEx(Size(), 1, BLACK);
        }
        public void Accept(IFigure.IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public int UID() {return uid;}
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

        // NOTE: Relative move/resize!
        public void Resize(float x, float y)
        {
            foreach(var f in figures)
                f.Resize(x,y);
        }
        public void Move(float x, float y)
        {
            foreach(var f in figures)
                f.Move(x,y);
        }
        public void RelResize(float x, float y)
        {
            foreach(var f in figures)
                f.RelResize(x,y);
        }
        public void RelMove(float x, float y)
        {
            foreach(var f in figures)
                f.RelMove(x,y);
        }

        public List<IFigure> figures = new List<IFigure>();
    }
}
