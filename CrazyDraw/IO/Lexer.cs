using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        public Lexeme(TokenType type, string str, int number) { this.type = type; this.str = str; this.number = number; }
        TokenType type;
        string str;
        int number;
    }

    class Lexer
    {
        static public List<string> Split(string sentence) {
            List<string> Lexed = new List<string>();

            int pos = 0;
            int currentEntry = 0;
            Lexed.Add("");

            while (pos < sentence.Length)
            {
                if (sentence[pos] != ' ' && sentence[pos] != '\t' && sentence[pos] != '\n')
                {
                    Lexed[currentEntry] = Lexed[currentEntry] + sentence[pos];
                }
                else
                {
                    ++currentEntry;
                    if (sentence[pos] == '\n') Lexed.Add("\n");
                    if (sentence[pos] == '\t') Lexed.Add("\t");
                    if (sentence[pos] == ' ') Lexed.Add(" ");
                    ++currentEntry;
                    Lexed.Add("");
                }
                ++pos;
            }
            return Lexed;
        }

        static public List<Lexeme> Lex(List<string> splitSentence) {
            List<Lexeme> lexemes = new List<Lexeme>();

            foreach(var lexeme in splitSentence)
            {
                if (lexeme == "\n") ;
                else if (lexeme == "\t") ;
                else if (lexeme == " ") ;
                else if (lexeme == "") ;
                else if (int.TryParse(lexeme, out _)) lexemes.Add(new Lexeme(TokenType.NUMBER, lexeme, int.Parse(lexeme)));
                else if (lexeme == "group") lexemes.Add(new Lexeme(TokenType.GROUP, lexeme, 0));
                else if (lexeme == "ornament") lexemes.Add(new Lexeme(TokenType.ORNAMENT, lexeme, 0));
                else if (lexeme == "ellipse") lexemes.Add(new Lexeme(TokenType.ELLIPSE, lexeme, 0));
                else if (lexeme == "rectangle") lexemes.Add(new Lexeme(TokenType.RECTANGLE, lexeme, 0));
                else if (lexeme == "top" || lexeme == "bottom" || lexeme == "left" || lexeme == "right") lexemes.Add(new Lexeme(TokenType.DIRECTION, lexeme, 0));
                else lexemes.Add(new Lexeme(TokenType.STRING, lexeme, 0));
            }
            return lexemes;
        }

    }
}
