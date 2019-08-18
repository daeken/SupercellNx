namespace CxxDemangler.Parsers
{
    // <class-enum-type> ::= <name>     # non-dependent type name, dependent type name, or dependent typename-specifier
    //                   ::= Ts <name>  # dependent elaborated type specifier using 'struct' or 'class'
    //                   ::= Tu <name>  # dependent elaborated type specifier using 'union'
    //                   ::= Te<name>  # dependent elaborated type specifier using 'enum'
    internal class ClassEnumType
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            IParsingResultExtended name = Name.Parse(context);

            if (name != null)
            {
                return name;
            }

            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("T"))
            {
                if (context.Parser.VerifyString("s"))
                {
                    name = Name.Parse(context);
                    if (name != null)
                    {
                        return new ElaboratedStruct(name);
                    }
                }
                else if (context.Parser.VerifyString("u"))
                {
                    name = Name.Parse(context);
                    if (name != null)
                    {
                        return new ElaboratedUnion(name);
                    }
                }
                else if (context.Parser.VerifyString("e"))
                {
                    name = Name.Parse(context);
                    if (name != null)
                    {
                        return new ElaboratedEnum(name);
                    }
                }
            }

            context.Rewind(rewind);
            return null;
        }

        internal class ElaboratedEnum : IParsingResultExtended
        {
            public ElaboratedEnum(IParsingResultExtended name)
            {
                Name = name;
            }

            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("enum ");
                Name.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name.GetTemplateArgs();
            }
        }

        internal class ElaboratedStruct : IParsingResultExtended
        {
            public ElaboratedStruct(IParsingResultExtended name)
            {
                Name = name;
            }

            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("class ");
                Name.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name.GetTemplateArgs();
            }
        }

        internal class ElaboratedUnion : IParsingResultExtended
        {
            public ElaboratedUnion(IParsingResultExtended name)
            {
                Name = name;
            }

            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("union ");
                Name.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name.GetTemplateArgs();
            }
        }
    }
}
