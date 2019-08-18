namespace CxxDemangler.Parsers
{
    // <function-type> ::= [<CV-qualifiers>] [Dx] F [Y] <bare-function-type> [<ref-qualifier>] E
    internal class FunctionType : IParsingResultExtended
    {
        public FunctionType(BareFunctionType bareType, CvQualifiers cvQualifiers, RefQualifier refQualifier, bool transactionSafe, bool externC)
        {
            CvQualifiers = cvQualifiers;
            TransactionSafe = transactionSafe;
            ExternC = externC;
            BareType = bareType;
            RefQualifier = refQualifier;
        }

        public CvQualifiers CvQualifiers { get; private set; }

        public bool TransactionSafe { get; private set; }

        public bool ExternC { get; private set; }

        public BareFunctionType BareType { get; private set; }

        public RefQualifier RefQualifier { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;
            CvQualifiers cvQualifiers = CvQualifiers.Parse(context);
            bool transactionSafe = context.Parser.VerifyString("Dx");

            if (context.Parser.VerifyString("F"))
            {
                bool externC = context.Parser.VerifyString("Y");
                BareFunctionType bareType = BareFunctionType.Parse(context);

                if (bareType != null)
                {
                    RefQualifier refQualifier = RefQualifier.Parse(context);

                    if (context.Parser.VerifyString("E"))
                    {
                        return new FunctionType(bareType, cvQualifiers, refQualifier, transactionSafe, externC);
                    }
                }
            }

            context.Rewind(rewind);
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            // TODO: transactions safety?
            // TODO: extern C?
            BareType.Demangle(context);
            CvQualifiers?.Demangle(context);
            // TODO: ref_qualifier?
        }

        public TemplateArgs GetTemplateArgs()
        {
            return null;
        }
    }
}
