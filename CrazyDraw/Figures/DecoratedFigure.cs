﻿using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace CrazyDraw.Figures
{
    class DecoratedFigure : IFigure
    {
        IFigure figure;
        public DecoratedFigure(IFigure figure) { this.figure = figure; }
        public void Update() { }
        public void Draw() { }
        public int UID() { return 1; }
        public Rectangle Size() { return new Rectangle(0, 0, 0, 0); }

    }
}
