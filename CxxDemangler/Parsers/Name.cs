namespace CxxDemangler.Parsers
{
    // <name> ::= <nested-name>
    //        ::= <unscoped-name>
    //        ::= <unscoped-template-name> <template-args>
    //        ::= <local-name>
    internal class Name
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;
            IParsingResultExtended name = NestedName.Parse(context);

            if (name != null)
            {
                return name;
            }

            name = UnscopedName.Parse(context);
            if (name != null)
            {
                if (context.Parser.Peek == 'I')
                {
                    context.SubstitutionTable.Add(name);
                    TemplateArgs args = TemplateArgs.Parse(context);

                    if (args == null)
                    {
                        context.Rewind(rewind);
                        return null;
                    }

                    return new UnscopedTemplate(name, args);
                }
                else
                {
                    return name;
                }
            }

            name = UnscopedTemplateName.Parse(context);
            if (name != null)
            {
                TemplateArgs args = TemplateArgs.Parse(context);

                if (args == null)
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new UnscopedTemplate(name, args);
            }

            return LocalName.Parse(context);
        }

        internal class UnscopedTemplate : IParsingResultExtended
        {
            public UnscopedTemplate(IParsingResultExtended name, TemplateArgs args)
            {
                Name = name;
                Args = args;
            }

            public IParsingResultExtended Name { get; private set; }

            public TemplateArgs Args { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                // Use new context with arguments on stack for name demangling
                DemanglingContext tempContext = context;

                tempContext.Stack.Push(Args);
                Name.Demangle(tempContext);

                // Return to old context
                Args.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Args;
            }
        }
    }
}
