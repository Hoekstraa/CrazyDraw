using System;
using System.Collections.Generic;
using CrazyDraw.Figures;

namespace CrazyDraw.IO
{
    class Parser
    {
        List<Lexeme> tokens;

        public Parser(List<Lexeme> lexemes)
        {
            tokens = lexemes; //tokens.Reverse(); //NOTICE: REVERSE LOGIC FROM C++ CODE!
        }

        public Group Parse()
        {
            Group result = new Group();
            var start = Pop();
            if(start.type == TokenType.GROUP) result = Grp();
            else Console.WriteLine("[Error] File doesn't start with group!");
            return result;
        }

        private Lexeme Pop()
        {
            var l = tokens[0];
            tokens.RemoveAt(0);
            return l;
        }
        private Lexeme Peek(){return tokens[0];}
        private Group Grp()
        {
            var result = new Group();
            Lexeme current = Pop();
            int subfigures = 0;

            if(current.type == TokenType.NUMBER)
                subfigures = current.number;
            else
                Console.WriteLine("[Error] Group doesn't have a number after it!");

            for (int i = 0; i < subfigures; i++)
            {
                IFigure f = Fig(Pop());
                Console.WriteLine("[DEBUG] Made an IFigure.");
                if(f == null) Console.WriteLine("[Error] IFigureis null.");
                result.figures.Add(f);
                Console.WriteLine("[DEBUG] Added an IFigure to group.");
            }   
            Console.WriteLine("Made a group of size " + result.figures.Count);
            return result;
        }

        private IFigure Fig(Lexeme figure)
        {

            IFigure result;
            String north = "";
            String south = "";
            String west = "";
            String east = "";

            while (figure.type == TokenType.ORNAMENT)
            {
                Console.WriteLine("[DEBUG] Reading in a: " + figure.str); // Print lexeme type for debugging
                // tokentype is ornament
                // tokentype should be direction
                var direction = Pop();
                // tokentype should be string with text
                var content = Pop();
                if(direction.str == "north") north = content.str;
                if(direction.str == "south") south = content.str;
                if(direction.str == "west") west = content.str;
                if(direction.str == "east") east = content.str;

                figure = Pop();
            }

            if(figure.type == TokenType.RECTANGLE)
            {
                Console.WriteLine("[DEBUG] Reading in a: " + figure.str); // Print lexeme type for debugging
                result = new BasicFigure(Pop().number,Pop().number,Pop().number,Pop().number,BasicFigure.RectangleStrategy.Instance);
            }
            else if(figure.type == TokenType.ELLIPSE)
            {
                Console.WriteLine("[DEBUG] Reading in a: " + figure.str); // Print lexeme type for debugging
                result = new BasicFigure(Pop().number,Pop().number,Pop().number,Pop().number,BasicFigure.EllipseStrategy.Instance);
            }
            else if(figure.type == TokenType.GROUP)
            {
                Console.WriteLine("[DEBUG] Reading in a: " + figure.str); // Print lexeme type for debugging
                result = Grp();
            }
            else
            {
                Console.WriteLine("[DEBUG] Reading in a: " + figure.str); // Print lexeme type for debugging
                return new BasicFigure(0,0,0,0, BasicFigure.RectangleStrategy.Instance);
            }

            var decoratedResult = new DecoratedFigure(result);
            if(north != "")
                decoratedResult.North(north);
            if(south != "")
                decoratedResult.South(south);
            if(east != "")
                decoratedResult.East(east);
            if(west != "")
                decoratedResult.West(west);

            if(north != "" || south != "" || east != "" || west != "")
                return decoratedResult;

            return result;
        }
    }
}
