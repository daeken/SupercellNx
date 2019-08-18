namespace CxxDemangler.Parsers
{
    // <data-member-prefix> := <member source-name> M
    internal class DataMemberPrefix
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;
            IParsingResult name = SourceName.Parse(context);

            if (name != null && context.Parser.VerifyString("M"))
            {
                return name;
            }
            context.Rewind(rewind);
            return null;
        }

        public static bool StartsWith(ParsingContext context)
        {
            return SourceName.StartsWith(context);
        }
    }
}
