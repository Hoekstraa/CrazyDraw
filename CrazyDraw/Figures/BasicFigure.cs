using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;
using System.Collections.Generic;
using System;

namespace CrazyDraw.Figures
{
    partial class BasicFigure : IFigure
    {
        /// <summary>
        /// Internal so Visitors can interact.
        /// </summary>
        internal float posX;
        internal float posY;
        internal float width;
        internal float height;
        Color color = SKYBLUE;
        internal bool mouseScaleReady = false;
        internal bool mouseScaleMode = false;
        internal bool selected = false;
        internal bool mouseMoveMode = false;
        internal Vector2 mousePositionLastFrame = new Vector2(0, 0);
        int uid;
        Strategy strat;

        /// <summary>
        /// Used for Move Command
        /// </summary>
        internal float OldX { get; set; }
        internal float OldY { get; set; }
        /// <summary>
        /// Used for Resize Command
        /// </summary>
        internal float OldWidth { get; set; }
        internal float OldHeight { get; set; }

        public BasicFigure(float posX, float posY, float width, float height, Strategy strat)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
            this.strat = strat;
            uid = Global.UniqueId;
            Global.UniqueId += 1;
        }
        
        public string ToString(int indent)
        {
            return "not complete! (BasicFigure)";
        }

        public void Draw() {
            strat.Draw(posX,posY,width,height, color,selected,mouseScaleReady);
        }

        public void Accept(IFigure.IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int UID() { return uid; }

        public bool Collide(Vector2 point) { return strat.Collide(posX, posY, width, height, point); }

        public Rectangle Size() { return new Rectangle(posX, posY, width, height); }

        public void Resize(float x, float y) { width = x; height = y; }
        public void Move(float x, float y) { posX = x; posY = y; }
        public void RelResize(float x, float y) { width += x; height += y; }
        public void RelMove(float x, float y) { posX += x; posY += y; }
    }
}
