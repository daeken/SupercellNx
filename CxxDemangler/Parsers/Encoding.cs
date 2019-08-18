namespace CxxDemangler.Parsers
{
    // <encoding> ::= <function name> <bare-function-type>
    //            ::= <data name>
    //            ::= <special-name>
    internal class Encoding
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            IParsingResultExtended name = Name.Parse(context);

            if (name != null)
            {
                BareFunctionType type = BareFunctionType.Parse(context);

                if (type != null)
                {
                    return new Function(name, type);
                }

                return name;
            }

            return SpecialName.Parse(context);
        }

        internal class Function : IParsingResult, IDemangleAsInner
        {
            public Function(IParsingResultExtended name, BareFunctionType type)
            {
                Name = name;
                Type = type;
            }

            public IParsingResultExtended Name { get; private set; }

            public BareFunctionType Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                // Whether the first type in the BareFunctionType is a return
                // type or parameter depends on the context in which it
                // appears.
                //
                // * Templates and functions in a type or parameter position
                // always have return types.
                //
                // * Non-template functions that are not in a type or parameter
                // position do not have a return type.
                //
                // We know we are not printing a type, so we only need to check
                // whether this is a template.
                //
                // For the details, see
                // http://itanium-cxx-abi.github.io/cxx-abi/abi.html#mangle.function-type
                TemplateArgs templateArgs = Name.GetTemplateArgs();

                if (templateArgs != null)
                {
                    context.Stack.Push(templateArgs);
                    Type.Demangle(context);
                    context.Writer.Append(" ");
                }

                context.Inner.Push(this);
                Name.Demangle(context);
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public void DemangleAsInner(DemanglingContext context)
            {
                TemplateArgs templateArgs = Name.GetTemplateArgs();

                if (templateArgs != null)
                {
                    context.Stack.Push(templateArgs);
                    Type.DemangleWithoutType(context);
                }
                else
                {
                    Type.DemangleWithType(context);
                }
            }
        }
    }
}
