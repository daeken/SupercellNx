namespace CxxDemangler.Parsers
{
    // <closure-type-name> ::= Ul <lambda-sig> E [ <nonnegative number> ] _
    internal class ClosureTypeName : IParsingResultExtended
    {
        public ClosureTypeName(IParsingResult signature, int? number)
        {
            Signature = signature;
            Number = number;
        }

        public IParsingResult Signature { get; private set; }

        public int? Number { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("Ul"))
            {
                return null;
            }

            IParsingResult signature = LambdaSig.Parse(context);

            if (signature == null || !context.Parser.VerifyString("E"))
            {
                context.Rewind(rewind);
                return null;
            }

            int? number = context.Parser.ParseNumber();

            if (!context.Parser.VerifyString("_"))
            {
                context.Rewind(rewind);
                return null;
            }

            return new ClosureTypeName(signature, number);
        }

        public void Demangle(DemanglingContext context)
        {
            int number = Number.HasValue ? Number.Value + 1 : 0;

            context.Writer.Append("{lambda(");
            Signature.Demangle(context);
            context.Writer.Append($")#{number}}}");
        }

        public TemplateArgs GetTemplateArgs()
        {
            return null;
        }
    }
}
