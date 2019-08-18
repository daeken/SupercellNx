namespace CxxDemangler.Parsers
{
    // <function-param> ::= fp <top-level CV-qualifiers> _                             # L == 0, first parameter
    //          ::= fp <top-level CV-qualifiers> <parameter-2 non-negative number> _   # L == 0, second and later parameters
    //          ::= fL <L-1 non-negative number> p <top-level CV-qualifiers> _         # L > 0, first parameter
    //          ::= fL <L-1 non-negative number> p <top-level CV-qualifiers>
    //                                           <parameter-2 non-negative number> _   # L > 0, second and later parameters
    internal class FunctionParam : IParsingResult
    {
        public FunctionParam(CvQualifiers cvQualifiers, int scope, int? param)
        {
            CvQualifiers = cvQualifiers;
            Scope = scope;
            Param = param;
        }

        public int Scope { get; private set; }

        public CvQualifiers CvQualifiers { get; private set; }

        public int? Param { get; private set; }

        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("f"))
            {
                return null;
            }

            int scope = 0;

            if (context.Parser.VerifyString("L"))
            {
                if (!context.Parser.ParseNumber(out scope))
                {
                    context.Rewind(rewind);
                    return null;
                }
            }

            if (context.Parser.VerifyString("p"))
            {
                CvQualifiers qualifiers = CvQualifiers.Parse(context);
                int? param = context.Parser.ParseNumber();

                if (context.Parser.VerifyString("_"))
                {
                    return new FunctionParam(qualifiers, scope, param);
                }
            }

            context.Rewind(rewind);
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            // TODO: this needs more finesse.
            IParsingResult arg = context.Stack.GetFunctionArg(Scope);

            arg?.Demangle(context);
        }
    }
}
