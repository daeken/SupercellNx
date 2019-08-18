using System.Collections.Generic;

namespace CxxDemangler.Parsers
{
    // <initializer> ::= pi <expression>* E                                  # parenthesized initialization
    internal class Initializer : IParsingResult
    {
        public Initializer(IReadOnlyList<IParsingResult> expressions)
        {
            Expressions = expressions;
        }

        public IReadOnlyList<IParsingResult> Expressions { get; private set; }

        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("pi"))
            {
                return null;
            }

            List<IParsingResult> expressions = CxxDemangler.ParseList(Expression.Parse, context);

            if (context.Parser.VerifyString("E"))
            {
                return new Initializer(expressions);
            }

            context.Rewind(rewind);
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            context.Writer.Append("(");
            Expressions.Demangle(context);
            context.Writer.Append(")");
        }
    }
}
