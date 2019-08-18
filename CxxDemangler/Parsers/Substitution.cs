namespace CxxDemangler.Parsers
{
    // <substitution> ::= S <seq-id> _
    //                ::= S_
    // <substitution> ::= St # ::std::
    // <substitution> ::= Sa # ::std::allocator
    // <substitution> ::= Sb # ::std::basic_string
    // <substitution> ::= Ss # ::std::basic_string < char,
    //                         ::std::char_traits<char>,
    //                         ::std::allocator<char> >
    // <substitution> ::= Si # ::std::basic_istream<char,  std::char_traits<char> >
    // <substitution> ::= So # ::std::basic_ostream<char,  std::char_traits<char> >
    // <substitution> ::= Sd # ::std::basic_iostream<char, std::char_traits<char> >
    internal class Substitution : IParsingResultExtended
    {
        private IParsingResult resolvedReference;

        public Substitution(int reference)
        {
            Reference = reference;
        }

        public int Reference { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            IParsingResultExtended wellKnown = WellKnownComponent.Parse(context);

            if (wellKnown != null)
            {
                return wellKnown;
            }

            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("S"))
            {
                return null;
            }

            int number;

            if (!context.Parser.ParseNumberBase36(out number))
            {
                number = -1;
            }
            number++;


            if (!context.Parser.VerifyString("_") || !context.SubstitutionTable.Contains(number))
            {
                context.Rewind(rewind);
                return null;
            }

            Substitution substitution = new Substitution(number);

            substitution.resolvedReference = context.SubstitutionTable.Substitutions[number];
            return substitution;
        }

        public void Demangle(DemanglingContext context)
        {
            IParsingResult reference = resolvedReference ?? context.SubstitutionTable.Substitutions[Reference];

            reference.Demangle(context);
        }

        public TemplateArgs GetTemplateArgs()
        {
            IParsingResultExtended extended = resolvedReference as IParsingResultExtended;

            return extended?.GetTemplateArgs();
        }
    }
}
