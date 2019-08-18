namespace CxxDemangler.Parsers
{
    internal class WellKnownComponent : IParsingResultExtended
    {
        public enum Values
        {
            [DictionaryValue("St", "std")]
            Std,

            [DictionaryValue("Sa", "std::allocator")]
            StdAllocator,

            [DictionaryValue("Sb", "std::basic_string")]
            StdString1,

            [DictionaryValue("Ss", "std::string")]
            StdString2,

            [DictionaryValue("Si", "std::basic_istream<char, std::char_traits<char> >")]
            StdIstream,

            [DictionaryValue("So", "std::ostream")]
            StdOstream,

            [DictionaryValue("Sd", "std::basic_iostream<char, std::char_traits<char> >")]
            StdIostream,
        }

        public WellKnownComponent(Values value)
        {
            Value = value;
        }

        public Values Value { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            Values value;

            if (DictionaryParser<Values>.Parse(context, out value))
            {
                return new WellKnownComponent(value);
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

        public TemplateArgs GetTemplateArgs()
        {
            return null;
        }
    }
}
