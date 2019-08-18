namespace CxxDemangler.Parsers
{
    // <unqualified-name> ::= <operator-name> [<abi-tags>]
    //                    ::= <ctor-dtor-name>
    //                    ::= <source-name>
    //                    ::= <unnamed-type-name>
    //                    ::= DC <source-name>+ E      # structured binding declaration
    internal class UnqualifiedName
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            return OperatorName.Parse(context) ?? CtorDtorName.Parse(context) ?? SourceName.Parse(context) ?? UnnamedTypeName.Parse(context);
        }

        public static bool StartsWith(ParsingContext context)
        {
            return OperatorName.StartsWith(context) || CtorDtorName.StartsWith(context) || SourceName.StartsWith(context) || UnnamedTypeName.StartsWith(context);
        }
    }
}
