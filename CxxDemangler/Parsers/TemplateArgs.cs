using System.Collections.Generic;

namespace CxxDemangler.Parsers
{
    // <template-args> ::= I <template-arg>+ E
    internal class TemplateArgs : IParsingResult, IArgumentScope
    {
        public TemplateArgs(IReadOnlyList<IParsingResult> arguments)
        {
            Arguments = arguments;
        }

        public IReadOnlyList<IParsingResult> Arguments { get; private set; }

        public static TemplateArgs Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("I"))
            {
                List<IParsingResult> args = CxxDemangler.ParseList(TemplateArg.Parse, context);

                if (args.Count > 0 && context.Parser.VerifyString("E"))
                {
                    return new TemplateArgs(args);
                }
                context.Rewind(rewind);
            }

            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            context.Writer.Append("<");
            Arguments.Demangle(context);
            if (context.Writer.Last == '>')
            {
                context.Writer.Append(" ");
            }
            context.Writer.Append(">");
        }

        public IParsingResult GetFunctionArg(int scope)
        {
            if (scope >= 0 && scope < Arguments.Count)
            {
                return Arguments[scope];
            }
            return null;
        }

        public IParsingResult GetTemplateArg(int number)
        {
            return null;
        }
    }
}
