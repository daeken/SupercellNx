namespace CxxDemangler.Parsers
{
    // <decltype>  ::= Dt <expression> E  # decltype of an id-expression or class member access (C++0x)
    //             ::= DT<expression> E  # decltype of an expression (C++0x)
    internal class Decltype : IParsingResultExtended
    {
        public Decltype(IParsingResult expression, bool idExpression)
        {
            Expression = expression;
            IdExpression = idExpression;
        }

        public bool IdExpression { get; private set; }

        public IParsingResult Expression { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("D"))
            {
                return null;
            }

            if (context.Parser.VerifyString("t"))
            {
                IParsingResult expression = Parsers.Expression.Parse(context);

                if (expression == null || !context.Parser.VerifyString("E"))
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new Decltype(expression, idExpression: true);
            }

            if (context.Parser.VerifyString("T"))
            {
                IParsingResult expression = Parsers.Expression.Parse(context);

                if (expression == null || !context.Parser.VerifyString("E"))
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new Decltype(expression, idExpression: false);
            }

            context.Rewind(rewind);
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            context.Writer.Append("decltype (");
            Expression.Demangle(context);
            context.Writer.Append(")");
        }

        public TemplateArgs GetTemplateArgs()
        {
            return null;
        }
    }
}
