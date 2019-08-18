namespace CxxDemangler.Parsers
{
    // <destructor-name> ::= <unresolved-type>                               # e.g., ~T or ~decltype(f())
    //                   ::= <simple-id>                                     # e.g., ~A<2*N>
    internal class DestructorName : IParsingResult
    {
        public DestructorName(IParsingResult name)
        {
            Name = name;
        }

        public IParsingResult Name { get; private set; }

        public static IParsingResult Parse(ParsingContext context)
        {
            IParsingResult name = UnresolvedType.Parse(context) ?? SimpleId.Parse(context);

            if (name != null)
            {
                return new DestructorName(name);
            }
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            context.Writer.Append("~");
            Name.Demangle(context);
        }
    }
}
