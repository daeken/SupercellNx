namespace CxxDemangler.Parsers
{
    // <expr-primary> ::= L <type> <value number> E                          # integer literal
    //                ::= L <type> <value float> E                           # floating literal
    //                ::= L <string type> E                                  # string literal
    //                ::= L <nullptr type> E                                 # nullptr literal (i.e., "LDnE")
    //                ::= L <pointer type> 0 E                               # null pointer template argument
    //                ::= L <type> <real-part float> _ <imag-part float> E   # complex floating point literal (C 2000)
    //                ::= L <mangled-name> E                                 # external name
    internal class ExprPrimary
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("L"))
            {
                return null;
            }

            IParsingResult type = Type.Parse(context);

            if (type != null)
            {
                string literal = context.Parser.ParseUntil('E');

                if (context.Parser.VerifyString("E"))
                {
                    return new Literal(type, literal);
                }

                context.Rewind(rewind);
                return null;
            }

            IParsingResult name = MangledName.Parse(context);

            if (name != null && context.Parser.VerifyString("E"))
            {
                return new External(name);
            }

            context.Rewind(rewind);
            return null;
        }

        internal class External : IParsingResult
        {
            public External(IParsingResult name)
            {
                Name = name;
            }

            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Name.Demangle(context);
            }
        }

        internal class Literal : IParsingResult
        {
            public Literal(IParsingResult type, string name)
            {
                Type = type;
                Name = name;
            }

            public IParsingResult Type { get; private set; }

            public string Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                StandardBuiltinType nullptr = Type as StandardBuiltinType;

                if (nullptr != null && nullptr.Value == StandardBuiltinType.Values.Nullptr)
                {
                    context.Writer.Append("nullptr");
                }
                else if (context.GccCompatibleDemangle && !string.IsNullOrEmpty(Name))
                {
                    context.Writer.Append("(");
                    Type.Demangle(context);
                    context.Writer.Append(")");
                    context.Writer.Append(Name);
                }
                else
                {
                    Type.Demangle(context);
                    context.Writer.Append(Name);
                }
            }
        }
    }
}
