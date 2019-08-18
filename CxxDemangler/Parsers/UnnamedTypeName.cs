namespace CxxDemangler.Parsers
{
    // <unnamed-type-name> ::= Ut [ <nonnegative number> ] _
    internal class UnnamedTypeName : IParsingResultExtended
    {
        public UnnamedTypeName(int? number)
        {
            Number = number;
        }

        public int? Number { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("Ut"))
            {
                int? number = context.Parser.ParseNumber();

                if (context.Parser.VerifyString("_"))
                {
                    return new UnnamedTypeName(number);
                }
                context.Rewind(rewind);
            }

            return ClosureTypeName.Parse(context);
        }

        public static bool StartsWith(ParsingContext context)
        {
            return context.Parser.Peek == 'U';
        }

        public void Demangle(DemanglingContext context)
        {
            int number = Number.HasValue ? Number.Value + 1 : 0;

            context.Writer.Append($"{{unnamed type {number}}}");
        }

        public TemplateArgs GetTemplateArgs()
        {
            return null;
        }
    }
}
