namespace CxxDemangler.Parsers
{
    // <unscoped-template-name> ::= <unscoped-name>
    //                          ::= <substitution>
    internal class UnscopedTemplateName
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            IParsingResultExtended name = UnscopedName.Parse(context);

            if (name != null)
            {
                context.SubstitutionTable.Add(name);
                return name;
            }

            return Substitution.Parse(context);
        }
    }
}
