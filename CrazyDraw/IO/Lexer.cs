using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDraw.IO
{
    enum TokenType
    {
        GROUP,
        RECTANGLE,
        ELLIPSE,
        ORNAMENT,
        DIRECTION,
        STRING,
        NUMBER,
        ENDLINE,
        INDENT,
        END
    }

    struct Lexeme
    {
        TokenType type;
        string str;
        int number;
    }

    class Lexer
    {
        List<string> Split(string sentence) { }
        public List<Lexeme> Lex(List<string> splitSentence) { }

    }
}
