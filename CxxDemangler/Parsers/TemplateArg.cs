using System.Collections.Generic;

namespace CxxDemangler.Parsers
{
    // <template-arg> ::= <type>                  # type or template
    //                ::= X<expression> E         # expression
    //                ::= <expr-primary>          # simple expressions
    //                ::= J<template-arg>* E      # argument pack
    internal class TemplateArg
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;
            IParsingResult expression;

            if (context.Parser.VerifyString("X"))
            {
                expression = Expression.Parse(context);
                if (expression != null && context.Parser.VerifyString("E"))
                {
                    return expression;
                }
                context.Rewind(rewind);
                return null;
            }

            expression = ExprPrimary.Parse(context);
            if (expression != null)
            {
                return expression;
            }

            IParsingResult type = Type.Parse(context);
            if (type != null)
            {
                return type;
            }

            if (context.Parser.VerifyString("J"))
            {
                List<IParsingResult> arguments = CxxDemangler.ParseList(TemplateArg.Parse, context);

                if (context.Parser.VerifyString("E"))
                {
                    return new ArgPack(arguments);
                }
                context.Rewind(rewind);
                return null;
            }
            return null;
        }

        internal class ArgPack : IParsingResult
        {
            public ArgPack(IReadOnlyList<IParsingResult> arguments)
            {
                Arguments = arguments;
            }

            public IReadOnlyList<IParsingResult> Arguments { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Arguments.Demangle(context);
            }
        }
    }
}
