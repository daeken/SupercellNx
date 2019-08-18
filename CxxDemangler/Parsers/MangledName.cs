namespace CxxDemangler.Parsers
{
    // <mangled-name> ::= _Z <encoding>
    internal class MangledName
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            if (!context.Parser.VerifyString("_Z") && !context.Parser.VerifyString("__Z"))
            {
                return null;
            }

            return Encoding.Parse(context) ?? Type.Parse(context);
        }
    }
}
