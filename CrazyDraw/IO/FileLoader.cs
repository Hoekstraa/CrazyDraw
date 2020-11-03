using System;
using System.IO;
using CrazyDraw.Figures;

namespace CrazyDraw.IO
{
    class FileLoader
    {
        String text;

        public FileLoader(String Filename)
        {
            text = File.ReadAllText(Filename);
        }
        public Group Read()
        {
            var lexed = Lexer.Lex(Lexer.Split(text));
            Parser p = new Parser(lexed);
            return p.Parse();
        }
    }
}
