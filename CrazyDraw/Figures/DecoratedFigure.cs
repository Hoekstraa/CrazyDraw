using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System;
using System.Numerics;

namespace CrazyDraw.Figures
{
    class DecoratedFigure : IFigure
    {
        IFigure figure;

        /*
           internal bool mouseScaleReady = false;
           internal bool mouseScaleMode = false;
           internal bool selected = false;
           internal bool mouseMoveMode = false;
           internal Vector2 mousePositionLastFrame = new Vector2(0, 0);
           internal float OldX;
           internal float OldY;
           internal float posX;
           internal float posY;
           */

        string north = "";
        string south = "";
        string east = "";
        string west = "";

        public DecoratedFigure(IFigure figure) { this.figure = figure; }
        public void Update() {figure.Update();}

        public void Draw()
        {
            figure.Draw();
            DrawTextRec(GetFontDefault(), south,
                    new Rectangle(figure.Size().x,figure.Size().y + 50, figure.Size().width,figure.Size().height),
                    20, 1, true, BLACK);
            DrawTextRec(GetFontDefault(), north,
                    new Rectangle(figure.Size().x, figure.Size().y - 20, figure.Size().width, figure.Size().height ),
                    20, 1, true, BLACK);
            DrawTextRec(GetFontDefault(), west,
                    new Rectangle(figure.Size().x-40, figure.Size().y, figure.Size().width, figure.Size().height),
                    20, 1, true, BLACK);
            DrawTextRec(GetFontDefault(), east,
                    new Rectangle(figure.Size().x, figure.Size().y, figure.Size().width, figure.Size().height),
                    20, 1, true, BLACK);

        }
        public int UID() { return 1; }
        public void Accept(IFigure.IVisitor visitor)
        {
            //visitor.Visit(this);
            figure.Accept(visitor);
        }
        public void South(string South) 
        {
            south = South;
        }
        public void West(string West)
        {
            west = West;
        }
        public void East(string East)
        {
            east = East;
        }
        public void North(string North)
        {
            north = North;
        }

        public bool Collide(Vector2 point) { Console.WriteLine("DecoratedFigure Collide() placeholder hit"); return false; }
        public Rectangle Size() { return figure.Size(); }

        public void Resize(float x, float y) { figure.Resize(x,y);}//Console.WriteLine("Resize DecoratedFigure hit"); }
        public void Move(float x, float y) { figure.Move(x,y);}//Console.WriteLine("Move DecoratedFigure hit"); }

    }
}
