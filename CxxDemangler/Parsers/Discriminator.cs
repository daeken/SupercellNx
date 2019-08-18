using System.Diagnostics;

namespace CxxDemangler.Parsers
{
    // <discriminator> := _ <non-negative number>      # when number < 10
    //                 := __ <non-negative number> _   # when number >= 10
    internal class Discriminator : IParsingResult
    {
        public Discriminator(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }

        public static Discriminator Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("_"))
            {
                return null;
            }

            if (context.Parser.VerifyString("_"))
            {
                int number;

                if (context.Parser.ParseNumber(out number))
                {
                    Debug.Assert(number >= 0);
                    if (number >= 10 && context.Parser.VerifyString("_"))
                    {
                        return new Discriminator(number);
                    }
                }
                context.Rewind(rewind);
                return null;
            }

            if (char.IsDigit(context.Parser.Peek))
            {
                int number = context.Parser.Peek - '0';

                context.Parser.Position++;
                return new Discriminator(number);
            }

            context.Rewind(rewind);
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            context.Writer.Append($"{Number}");
        }
    }
}
