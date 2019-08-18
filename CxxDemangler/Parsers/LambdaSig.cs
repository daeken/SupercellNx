using System.Collections.Generic;

namespace CxxDemangler.Parsers
{
    // <lambda-sig> ::= <parameter type>+  # Parameter types or "v" if the lambda has no parameters
    internal class LambdaSig : IParsingResult
    {
        public LambdaSig(IReadOnlyList<IParsingResult> argumentTypes)
        {
            ArgumentTypes = argumentTypes;
        }

        public IReadOnlyList<IParsingResult> ArgumentTypes { get; private set; }

        public static IParsingResult Parse(ParsingContext context)
        {
            if (context.Parser.VerifyString("v"))
            {
                return new LambdaSig(new IParsingResult[0]);
            }

            List<IParsingResult> argumentTypes = CxxDemangler.ParseList(Type.Parse, context);

            if (argumentTypes.Count > 0)
            {
                return new LambdaSig(argumentTypes);
            }
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            ArgumentTypes.Demangle(context);
        }
    }
}
