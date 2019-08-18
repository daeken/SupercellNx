namespace CxxDemangler.Parsers
{
    // <pointer-to-member-type> ::= M <class type> <member type>
    internal class PointerToMemberType : IParsingResultExtended, IDemangleAsInner
    {
        public PointerToMemberType(IParsingResult type, IParsingResult member)
        {
            Type = type;
            Member = member;
        }

        public IParsingResult Type { get; private set; }

        public IParsingResult Member { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("M"))
            {
                IParsingResult type = Parsers.Type.Parse(context);

                if (type != null)
                {
                    IParsingResult member = Parsers.Type.Parse(context);

                    if (member != null)
                    {
                        return new PointerToMemberType(type, member);
                    }
                }
                context.Rewind(rewind);
            }
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            context.Inner.Push(this);
            Member.Demangle(context);
            if (context.Inner.Count > 0)
            {
                context.Inner.Pop().DemangleAsInner(context);
            }
        }

        public void DemangleAsInner(DemanglingContext context)
        {
            if (context.Writer.Last != '(')
            {
                context.Writer.EnsureSpace();
            }
            Type.Demangle(context);
            context.Writer.Append("::*");
        }

        public TemplateArgs GetTemplateArgs()
        {
            return null;
        }
    }
}
