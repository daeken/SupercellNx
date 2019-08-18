namespace CxxDemangler.Parsers
{
    // <unscoped-name> ::= <unqualified-name>
    //                 ::= St <unqualified-name>   # ::std::
    internal class UnscopedName
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("St"))
            {
                IParsingResultExtended name = UnqualifiedName.Parse(context);

                if (name == null)
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new Std(name);
            }

            return UnqualifiedName.Parse(context);
        }

        internal class Std : IParsingResultExtended
        {
            public Std(IParsingResultExtended name)
            {
                Name = name;
            }

            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("std::");
                Name.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name.GetTemplateArgs();
            }
        }
    }
}
