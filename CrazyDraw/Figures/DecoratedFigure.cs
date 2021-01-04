using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System;
using System.Numerics;

namespace CrazyDraw.Figures
{
    class DecoratedFigure : IFigure
    {
        public IFigure figure;

        string north = "";
        string south = "";
        string east = "";
        string west = "";
        int uid;
        internal bool selected = false;

        public DecoratedFigure(IFigure figure) { this.figure = figure; uid = Global.UniqueId++; }

        public string ToString(int indents)
        {
            string indent = "";
            string result = "";

            for(int i = 0; i < indents; i++)
                indent += "\t";

            result += north == "" ? "" : indent + "ornament north " + north + "\n";
            result += east  == "" ? "" : indent + "ornament east "  + east  + "\n";
            result += south == "" ? "" : indent + "ornament south " + south + "\n";
            result += west  == "" ? "" : indent + "ornament west "  + west  + "\n";

            return result + figure.ToString(indents);
        }


        public void Draw()
        {
            figure.Draw();
            DrawTextRec(GetFontDefault(), south,
                    new Rectangle(figure.Size().x,figure.Size().y + figure.Size().height, 100, 40 ),
                    20, 1, true, BLACK);
            DrawTextRec(GetFontDefault(), north,
                    new Rectangle(figure.Size().x, figure.Size().y - 20, 100, 40 ),
                    20, 1, true, BLACK);
            DrawTextRec(GetFontDefault(), west,
                    new Rectangle(figure.Size().x-40, figure.Size().y, 100, 40),
                    20, 1, true, BLACK);
            DrawTextRec(GetFontDefault(), east,
                    new Rectangle(figure.Size().x + figure.Size().width, figure.Size().y, 100, 40 ),
                    20, 1, true, BLACK);

            if(selected);

        }
        public int UID() { return uid; }
        public void Accept(IFigure.IVisitor visitor)
        {
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

        public bool Collide(Vector2 point) { return figure.Collide(point); }
        public Rectangle Size() { return figure.Size(); }

        public void Resize(float x, float y) { figure.Resize(x,y);}
        public void Move(float x, float y) { figure.Move(x,y);}
        public void RelResize(float x, float y) { figure.RelResize(x,y);}
        public void RelMove(float x, float y) { figure.RelMove(x,y);}

    }
}
