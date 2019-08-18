namespace CxxDemangler.Parsers
{
    //  <base-unresolved-name> ::= <simple-id>                                # unresolved name
    //                         ::= on <operator-name>                         # unresolved operator-function-id
    //                         ::= on <operator-name> <template-args>         # unresolved operator template-id
    //                         ::= dn <destructor-name>                       # destructor or pseudo-destructor;
    //                                                                        # e.g. ~X or ~X<N-1>
    internal class BaseUnresolvedName
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;
            IParsingResult name = SimpleId.Parse(context);

            if (name != null)
            {
                return name;
            }
            if (context.Parser.VerifyString("on"))
            {
                IParsingResult operatorName = OperatorName.Parse(context);

                if (operatorName != null)
                {
                    IParsingResult arguments = TemplateArgs.Parse(context);

                    return new Operator(operatorName, arguments);
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("dn"))
            {
                return DestructorName.Parse(context);
            }
            return null;
        }

        internal class Operator : IParsingResult
        {
            public Operator(IParsingResult operatorName, IParsingResult arguments)
            {
                OperatorName = operatorName;
                Arguments = arguments;
            }

            public IParsingResult Arguments { get; private set; }

            public IParsingResult OperatorName { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                OperatorName.Demangle(context);
                Arguments?.Demangle(context);
            }
        }
    }
}
