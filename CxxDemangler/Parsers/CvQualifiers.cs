namespace CxxDemangler.Parsers
{
    // <CV-qualifiers> ::= [r] [V] [K] 	# restrict (C99), volatile, const
    internal class CvQualifiers : IParsingResult, IDemangleAsInner
    {
        public CvQualifiers(bool restrict = false, bool @volatile = false, bool @const = false)
        {
            Restrict = restrict;
            Volatile = @volatile;
            Const = @const;
        }

        public bool Restrict { get; private set; }

        public bool Volatile { get; private set; }

        public bool Const { get; private set; }

        public static CvQualifiers Parse(ParsingContext context)
        {
            CvQualifiers qualifiers = null;

            if (context.Parser.VerifyString("r"))
            {
                qualifiers = qualifiers ?? new CvQualifiers();
                qualifiers.Restrict = true;
            }

            if (context.Parser.VerifyString("V"))
            {
                qualifiers = qualifiers ?? new CvQualifiers();
                qualifiers.Volatile = true;
            }

            if (context.Parser.VerifyString("K"))
            {
                qualifiers = qualifiers ?? new CvQualifiers();
                qualifiers.Const = true;
            }

            return qualifiers;
        }

        public void Demangle(DemanglingContext context)
        {
            if (Const)
            {
                context.Writer.EnsureSpace();
                context.Writer.Append("const");
            }
            if (Volatile)
            {
                context.Writer.EnsureSpace();
                context.Writer.Append("volatile");
            }
            if (Restrict)
            {
                context.Writer.EnsureSpace();
                context.Writer.Append("restrict");
            }
        }

        public void DemangleAsInner(DemanglingContext context)
        {
            Demangle(context);
        }
    }
}
