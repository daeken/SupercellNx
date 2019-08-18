namespace CxxDemangler.Parsers
{
    // <unresolved-qualifier-level> ::= <simple-id>
    internal class UnresolvedQualifierLevel
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            return SimpleId.Parse(context);
        }
    }
}
