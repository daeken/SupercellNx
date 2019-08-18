namespace CxxDemangler.Parsers
{
    // <nested-name> ::= N [<CV-qualifiers>] [<ref-qualifier>] <prefix> <unqualified-name> E
    //               ::= N [<CV-qualifiers>] [<ref-qualifier>] <template-prefix> <template-args> E
    internal class NestedName : IParsingResultExtended
    {
        public NestedName(IParsingResultExtended prefix, CvQualifiers cvQualifiers, RefQualifier refQualifier)
        {
            Prefix = prefix;
            CvQualifiers = cvQualifiers;
            RefQualifier = refQualifier;
        }

        public IParsingResultExtended Prefix { get; private set; }

        public CvQualifiers CvQualifiers { get; private set; }

        public RefQualifier RefQualifier { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("N"))
            {
                return null;
            }

            CvQualifiers cvQualifiers = CvQualifiers.Parse(context);
            RefQualifier refQualifier = RefQualifier.Parse(context);
            IParsingResultExtended prefix = Parsers.Prefix.Parse(context);

            if (prefix == null)
            {
                context.Rewind(rewind);
                return null;
            }

            if (!(prefix is Parsers.Prefix.NestedName) && !(prefix is Parsers.Prefix.Template))
            {
                context.Rewind(rewind);
                return null;
            }

            if (!context.Parser.VerifyString("E"))
            {
                context.Rewind(rewind);
                return null;
            }

            return new NestedName(prefix, cvQualifiers, refQualifier);
        }

        public void Demangle(DemanglingContext context)
        {
            Prefix.Demangle(context);

            if (context.Inner.Count > 0)
            {
                context.Inner.Pop().DemangleAsInner(context);
            }

            CvQualifiers?.Demangle(context);
            if (RefQualifier != null)
            {
                context.Writer.EnsureSpace();
                RefQualifier.Demangle(context);
            }
        }

        public TemplateArgs GetTemplateArgs()
        {
            return Prefix.GetTemplateArgs();
        }
    }
}
