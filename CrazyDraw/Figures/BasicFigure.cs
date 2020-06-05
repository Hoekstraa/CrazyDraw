using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;
using System.Collections.Generic;

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
        Color color = BLUE;
        internal bool mouseScaleReady = false;
        internal bool mouseScaleMode = false;
        internal bool selected = false;
        internal bool mouseMoveMode = false;
        internal Vector2 mousePositionLastFrame = new Vector2(0, 0);
        int uid;
        Strategy strat;

        public BasicFigure(float posX, float posY, float width, float height)//, Strategy strat)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
            //this.strat = strat;
        }

        public void Update() { }
        public void Draw() {
            DrawRectangleRec(Size(), color);
        }
        public int UID() { return 1; }
        public Rectangle Size() { return new Rectangle(posX, posY, width, height); }

    }
}
