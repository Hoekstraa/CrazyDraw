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

        public void Update() { }
        public void Draw() {
            strat.Draw(posX,posY,width,height, color,selected,mouseScaleReady);
        }
        public int UID() { return uid; }

        public bool Collide(Vector2 point) { return strat.Collide(posX, posY, width, height, point); }

        public Rectangle Size() { return new Rectangle(posX, posY, width, height); }

        public void Resize(float x, float y) { width = x; height = y; }
    }
}
