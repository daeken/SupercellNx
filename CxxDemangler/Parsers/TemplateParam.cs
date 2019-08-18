namespace CxxDemangler.Parsers
{
    // <template-param> ::= T_	# first template parameter
    //                  ::= T <parameter-2 non-negative number> _
    internal class TemplateParam : IParsingResultExtended
    {
        public TemplateParam(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("T"))
            {
                int number;

                if (!context.Parser.ParseNumber(out number))
                {
                    number = -1;
                }
                number++;
                if (context.Parser.VerifyString("_"))
                {
                    return new TemplateParam(number);
                }
                context.Rewind(rewind);
            }

            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            IParsingResult arg = context.Stack.GetTemplateArg(Number);

            arg?.Demangle(context);
        }

        public TemplateArgs GetTemplateArgs()
        {
            return null;
        }
    }
}
