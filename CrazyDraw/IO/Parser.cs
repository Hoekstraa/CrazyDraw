using System;
using System.Collections.Generic;
using System.Text;
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
                result.figures.Add(Fig(Pop()));

            Console.WriteLine("Made a group of size " + result.figures.Count);
            return result;

        }
        private Ornament Ornmnt(Lexeme Ornament){return new Ornament(direction,string)}
        private Figure Fig(Lexeme figure){}
    }
}
