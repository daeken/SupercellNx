using System.Diagnostics;

namespace CxxDemangler.Parsers
{
    // <source-name> ::= <positive length number> <identifier>
    internal class SourceName
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;
            int nameLength;

            if (!context.Parser.ParseNumber(out nameLength))
            {
                return null;
            }

            if (nameLength <= 0)
            {
                context.Rewind(rewind);
                return null;
            }

            if (context.Parser.Position + nameLength <= context.Parser.Input.Length)
            {
                string identifier = context.Parser.Input.Substring(context.Parser.Position, nameLength);

                // Verify that identifier is correct
                bool correct = true;

                foreach (char c in identifier)
                {
                    if (c != '_' && c != '.' && !char.IsLetterOrDigit(c))
                    {
                        correct = false;
                        break;
                    }
                }
                if (!correct)
                {
                    context.Rewind(rewind);
                    return null;
                }

                context.Parser.Position += nameLength;

                return new Identifier(identifier);
            }

            return null;
        }

        public static bool StartsWith(ParsingContext context)
        {
            return char.IsDigit(context.Parser.Peek);
        }

        internal class Identifier : IParsingResultExtended
        {
            public Identifier(string name)
            {
                Name = name;
            }

            public string Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                // Handle GCC's anonymous namespace mangling.
                const string anonymusNamespacePrefix = "_GLOBAL_";

                if (Name.StartsWith(anonymusNamespacePrefix) && Name.Length >= anonymusNamespacePrefix.Length + 2)
                {
                    char first = Name[anonymusNamespacePrefix.Length];
                    char second = Name[anonymusNamespacePrefix.Length + 1];

                    if (second == 'N' && (first == '.' || first == '$' || first == '_'))
                    {
                        context.Writer.Append("(anonymous namespace)");
                        return;
                    }
                }

                context.Writer.Append(Name);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return null;
            }
        }
    }
}
