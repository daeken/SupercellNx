namespace CxxDemangler.Parsers
{
    // <local-name> := Z <function encoding> E <entity name> [<discriminator>]
    //              := Z <function encoding> E s [<discriminator>]
    internal class LocalName
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("Z"))
            {
                return null;
            }

            IParsingResult encoding = Encoding.Parse(context);
            IParsingResultExtended name;
            Discriminator discriminator;

            if (encoding == null || !context.Parser.VerifyString("E"))
            {
                context.Rewind(rewind);
                return null;
            }

            if (context.Parser.VerifyString("s"))
            {
                discriminator = Discriminator.Parse(context);
                return new Relative(encoding, null, discriminator);
            }

            if (context.Parser.VerifyString("d"))
            {
                int? param = context.Parser.ParseNumber();

                if (context.Parser.VerifyString("_"))
                {
                    name = Name.Parse(context);
                    if (name != null)
                    {
                        return new Default(encoding, param, name);
                    }
                }
                context.Rewind(rewind);
                return null;
            }
            name = Name.Parse(context);
            if (name != null)
            {
                discriminator = Discriminator.Parse(context);
                return new Relative(encoding, name, discriminator);
            }
            context.Rewind(rewind);
            return null;
        }

        internal class Default : IParsingResultExtended
        {
            public Default(IParsingResult encoding, int? param, IParsingResultExtended name)
            {
                Encoding = encoding;
                Param = param;
                Name = name;
            }

            public IParsingResult Encoding { get; private set; }

            public IParsingResultExtended Name { get; private set; }

            public int? Param { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                // TODO: We don't use Name and Param?
                Encoding.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name.GetTemplateArgs();
            }
        }

        internal class Relative : IParsingResultExtended
        {
            public Relative(IParsingResult encoding, IParsingResultExtended name, Discriminator discriminator)
            {
                Encoding = encoding;
                Name = name;
                Discriminator = discriminator;
            }

            public Discriminator Discriminator { get; private set; }

            public IParsingResult Encoding { get; private set; }

            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Encoding.Demangle(context);
                if (Name != null)
                {
                    context.Writer.Append("::");
                    Name.Demangle(context);
                }
                else
                {
                    // No name means that this is the symbol for a string literal.
                    context.Writer.Append("::string literal");
                }
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name?.GetTemplateArgs();
            }
        }
    }
}
