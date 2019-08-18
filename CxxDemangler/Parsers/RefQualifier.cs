namespace CxxDemangler.Parsers
{
    // <ref-qualifier> ::= R                   # & ref-qualifier
    // <ref-qualifier> ::= O                   # && ref-qualifier
    internal class RefQualifier : IParsingResult
    {
        public enum Values
        {
            [DictionaryValue("R", "&")]
            LValueRef,

            [DictionaryValue("O", "&&")]
            RValueRef,
        }

        public RefQualifier(Values value)
        {
            Value = value;
        }

        public Values Value { get; private set; }

        public static RefQualifier Parse(ParsingContext context)
        {
            Values value;

            if (DictionaryParser<Values>.Parse(context, out value))
            {
                return new RefQualifier(value);
            }

            return null;
        }

        public static bool StartsWith(ParsingContext context)
        {
            return DictionaryParser<Values>.StartsWith(context);
        }

        public void Demangle(DemanglingContext context)
        {
            DictionaryParser<Values>.Demangle(Value, context);
        }
    }
}
