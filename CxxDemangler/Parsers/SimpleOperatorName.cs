namespace CxxDemangler.Parsers
{
    internal class SimpleOperatorName : IParsingResultExtended
    {
        public SimpleOperatorName(Values value)
        {
            Value = value;
        }

        public Values Value { get; private set; }

        public enum Values
        {
            [DictionaryValue("nw", "new")]
            New,

            [DictionaryValue("na", "new[]")]
            NewArray,

            [DictionaryValue("dl", "delete")]
            Delete,

            [DictionaryValue("da", "delete[]")]
            DeleteArray,

            [DictionaryValue("ps", "+")]
            UnaryPlus,

            [DictionaryValue("ng", "-")]
            Negation,

            [DictionaryValue("ad", "&")]
            AddressOf,

            [DictionaryValue("de", "*")]
            Dereference,

            [DictionaryValue("co", "~")]
            BitNot,

            [DictionaryValue("pl", "+")]
            Plus,

            [DictionaryValue("mi", "-")]
            Minus,

            [DictionaryValue("ml", "*")]
            Multiply,

            [DictionaryValue("dv", "/")]
            Divide,

            [DictionaryValue("rm", "%")]
            Reminder,

            [DictionaryValue("an", "&")]
            BitAnd,

            [DictionaryValue("or", "|")]
            BitOr,

            [DictionaryValue("eo", "^")]
            BitXor,

            [DictionaryValue("aS", "=")]
            Assign,

            [DictionaryValue("pL", "+=")]
            PlusAssign,

            [DictionaryValue("mI", "-=")]
            MinusAssign,

            [DictionaryValue("mL", "*=")]
            MultiplyAssign,

            [DictionaryValue("dV", "/=")]
            DevideAssign,

            [DictionaryValue("rM", "%=")]
            ReminderAssign,

            [DictionaryValue("aN", "&=")]
            BitAndAssign,

            [DictionaryValue("oR", "|=")]
            BitOrAssign,

            [DictionaryValue("eO", "^=")]
            BitXorAssign,

            [DictionaryValue("ls", "<<")]
            LeftShift,

            [DictionaryValue("rs", ">>")]
            RightShift,

            [DictionaryValue("lS", "<<=")]
            LeftShiftAssign,

            [DictionaryValue("rS", ">>=")]
            RightShiftAssign,

            [DictionaryValue("eq", "==")]
            Equal,

            [DictionaryValue("ne", "!=")]
            NotEqual,

            [DictionaryValue("lt", "<")]
            Less,

            [DictionaryValue("gt", ">")]
            Greater,

            [DictionaryValue("le", "<=")]
            LessEqual,

            [DictionaryValue("ge", ">=")]
            GreaterEqual,

            [DictionaryValue("nt", "!")]
            Not,

            [DictionaryValue("aa", "&&")]
            LogicalAnd,

            [DictionaryValue("oo", "||")]
            LogicalOr,

            [DictionaryValue("pp", "++")]
            PostIncrement,

            [DictionaryValue("mm", "--")]
            PostDecrement,

            [DictionaryValue("cm", ",")]
            Comma,

            [DictionaryValue("pm", "->*")]
            DereferenceMemberPointer,

            [DictionaryValue("pt", "->")]
            DereferenceMember,

            [DictionaryValue("cl", "()")]
            Call,

            [DictionaryValue("ix", "[]")]
            Index,

            [DictionaryValue("qu", "?:")]
            Question,
        }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            Values value;

            if (DictionaryParser<Values>.Parse(context, out value))
            {
                return new SimpleOperatorName(value);
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
