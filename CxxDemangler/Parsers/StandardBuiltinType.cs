namespace CxxDemangler.Parsers
{
    internal class StandardBuiltinType : BuiltinType, IParsingResultExtended
    {
        public enum Values
        {
            [DictionaryValue("v", "void")]
            Void,

            [DictionaryValue("w", "wchar_t")]
            Wchar,

            [DictionaryValue("b", "bool")]
            Bool,

            [DictionaryValue("c", "char")]
            Char,

            [DictionaryValue("a", "signed char")]
            SignedChar,

            [DictionaryValue("h", "unsigned char")]
            UnsignedChar,

            [DictionaryValue("s", "short")]
            Short,

            [DictionaryValue("t", "unsigned short")]
            UnsignedShort,

            [DictionaryValue("i", "int")]
            Int,

            [DictionaryValue("j", "unsigned int")]
            UnsignedInt,

            [DictionaryValue("l", "long")]
            Long,

            [DictionaryValue("m", "unsigned long")]
            UnsignedLong,

            [DictionaryValue("x", "long long")]
            LongLong,

            [DictionaryValue("y", "unsigned long long")]
            UnsignedLongLong,

            [DictionaryValue("n", "__int128")]
            Int128,

            [DictionaryValue("o", "unsigned __int128")]
            Uint128,

            [DictionaryValue("f", "float")]
            Float,

            [DictionaryValue("d", "double")]
            Double,

            [DictionaryValue("e", "long double")]
            LongDouble,

            [DictionaryValue("g", "__float128")]
            Float128,

            [DictionaryValue("z", "...")]
            Ellipsis,

            [DictionaryValue("Dd", "decimal64")]
            DecimalFloat64,

            [DictionaryValue("De", "decimal128")]
            DecimalFloat128,

            [DictionaryValue("Df", "decimal32")]
            DecimalFloat32,

            [DictionaryValue("Dh", "decimal16")]
            DecimalFloat16,

            [DictionaryValue("Di", "char32_t")]
            Char32,

            [DictionaryValue("Ds", "char16_t")]
            Char16,

            [DictionaryValue("Da", "auto")]
            Auto,

            [DictionaryValue("Dc", "decltype(auto)")]
            Decltype,

            [DictionaryValue("Dn", "std::nullptr_t")]
            Nullptr,
        }

        public StandardBuiltinType(Values value)
        {
            Value = value;
        }

        public Values Value { get; private set; }

        public new static StandardBuiltinType Parse(ParsingContext context)
        {
            Values value;

            if (DictionaryParser<Values>.Parse(context, out value))
            {
                return new StandardBuiltinType(value);
            }

            return null;
        }

        public static bool StartsWith(ParsingContext context)
        {
            return DictionaryParser<Values>.StartsWith(context);
        }

        public override void Demangle(DemanglingContext context)
        {
            DictionaryParser<Values>.Demangle(Value, context);
        }

        public override TemplateArgs GetTemplateArgs()
        {
            return null;
        }
    }
}
