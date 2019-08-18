namespace CxxDemangler.Parsers
{
    //  <type> ::= <builtin-type>
    //         ::= <function-type>
    //         ::= <class-enum-type>
    //         ::= <array-type>
    //         ::= <pointer-to-member-type>
    //         ::= <template-param>
    //         ::= <template-template-param> <template-args>
    //         ::= <decltype>
    //         ::= <substitution>
    internal class Type
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            IParsingResultExtended type = BuiltinType.Parse(context);

            if (type != null)
            {
                return type;
            }

            type = ClassEnumType.Parse(context);
            if (type != null)
            {
                return AddToSubstitutionTable(context, type);
            }

            RewindState rewind = context.RewindState;

            type = Substitution.Parse(context);
            if (type != null)
            {
                if (context.Parser.Peek != 'I')
                {
                    return type;
                }

                context.Rewind(rewind);
            }

            type = FunctionType.Parse(context) ?? ArrayType.Parse(context) ?? PointerToMemberType.Parse(context);
            if (type != null)
            {
                return AddToSubstitutionTable(context, type);
            }

            type = TemplateParam.Parse(context);
            if (type != null)
            {
                if (context.Parser.Peek != 'I')
                {
                    return AddToSubstitutionTable(context, type);
                }

                context.Rewind(rewind);
            }

            type = TemplateTemplateParam.Parse(context);
            if (type != null)
            {
                TemplateArgs arguments = TemplateArgs.Parse(context);

                if (arguments == null)
                {
                    context.Rewind(rewind);
                    return null;
                }

                return AddToSubstitutionTable(context, new TemplateTemplate(type, arguments));
            }

            type = Decltype.Parse(context);
            if (type != null)
            {
                return type;
            }

            CvQualifiers qualifiers = CvQualifiers.Parse(context);

            if (qualifiers != null)
            {
                type = Parse(context);
                if (type == null)
                {
                    context.Rewind(rewind);
                    return null;
                }

                if (type is BuiltinType)
                {
                    return new QualifiedBuiltin(qualifiers, type);
                }
                return AddToSubstitutionTable(context, new Qualified(qualifiers, type));
            }

            if (context.Parser.VerifyString("P"))
            {
                type = Parse(context);
                if (type == null)
                {
                    context.Rewind(rewind);
                    return null;
                }
                return AddToSubstitutionTable(context, new PointerTo(type));
            }

            if (context.Parser.VerifyString("R"))
            {
                type = Parse(context);
                if (type == null)
                {
                    context.Rewind(rewind);
                    return null;
                }
                return AddToSubstitutionTable(context, new LvalueRef(type));
            }

            if (context.Parser.VerifyString("O"))
            {
                type = Parse(context);
                if (type == null)
                {
                    context.Rewind(rewind);
                    return null;
                }
                return AddToSubstitutionTable(context, new RvalueRef(type));
            }

            if (context.Parser.VerifyString("C"))
            {
                type = Parse(context);
                if (type == null)
                {
                    context.Rewind(rewind);
                    return null;
                }
                return AddToSubstitutionTable(context, new Complex(type));
            }

            if (context.Parser.VerifyString("G"))
            {
                type = Parse(context);
                if (type == null)
                {
                    context.Rewind(rewind);
                    return null;
                }
                return AddToSubstitutionTable(context, new Imaginary(type));
            }

            if (context.Parser.VerifyString("U"))
            {
                IParsingResult name = SourceName.Parse(context);

                if (name == null)
                {
                    context.Rewind(rewind);
                    return null;
                }

                TemplateArgs arguments = TemplateArgs.Parse(context);

                type = Parse(context);
                return AddToSubstitutionTable(context, new VendorExtension(name, arguments, type));
            }

            if (context.Parser.VerifyString("Dp"))
            {
                type = Parse(context);
                if (type == null)
                {
                    context.Rewind(rewind);
                    return null;
                }
                return AddToSubstitutionTable(context, new PackExtension(type));
            }

            return null;
        }

        private static IParsingResultExtended AddToSubstitutionTable(ParsingContext context, IParsingResultExtended result)
        {
            context.SubstitutionTable.Add(result);
            return result;
        }

        internal class Complex : IParsingResultExtended
        {
            public Complex(IParsingResultExtended type)
            {
                Type = type;
            }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                context.Writer.Append(" complex");
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class Imaginary : IParsingResultExtended
        {
            public Imaginary(IParsingResultExtended type)
            {
                Type = type;
            }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                context.Writer.Append(" imaginary");
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class LvalueRef : IParsingResultExtended, IDemangleAsInner
        {
            public LvalueRef(IParsingResultExtended type)
            {
                Type = type;
            }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Inner.Push(this);
                Type.Demangle(context);
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public void DemangleAsInner(DemanglingContext context)
            {
                context.Writer.Append("&");
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class PointerTo : IParsingResultExtended, IDemangleAsInner
        {
            public PointerTo(IParsingResultExtended type)
            {
                Type = type;
            }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Inner.Push(this);
                Type.Demangle(context);
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public void DemangleAsInner(DemanglingContext context)
            {
                context.Writer.Append("*");
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class RvalueRef : IParsingResultExtended, IDemangleAsInner
        {
            public RvalueRef(IParsingResultExtended type)
            {
                Type = type;
            }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Inner.Push(this);
                Type.Demangle(context);
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public void DemangleAsInner(DemanglingContext context)
            {
                context.Writer.Append("&&");
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class QualifiedBuiltin : IParsingResultExtended
        {
            public QualifiedBuiltin(CvQualifiers qualifiers, IParsingResultExtended type)
            {
                CvQualifiers = qualifiers;
                Type = type;
            }

            public CvQualifiers CvQualifiers { get; private set; }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Inner.Push(CvQualifiers);
                Type.Demangle(context);
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class Qualified : IParsingResultExtended
        {
            public Qualified(CvQualifiers qualifiers, IParsingResultExtended type)
            {
                CvQualifiers = qualifiers;
                Type = type;
            }

            public CvQualifiers CvQualifiers { get; private set; }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Inner.Push(CvQualifiers);
                Type.Demangle(context);
                if (context.Inner.Count > 0)
                {
                    context.Inner.Pop().DemangleAsInner(context);
                }
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class TemplateTemplate : IParsingResultExtended
        {
            public TemplateTemplate(IParsingResultExtended type, TemplateArgs arguments)
            {
                Type = type;
                Arguments = arguments;
            }

            public TemplateArgs Arguments { get; private set; }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                Arguments.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Arguments;
            }
        }

        internal class PackExtension : IParsingResultExtended
        {
            public PackExtension(IParsingResultExtended type)
            {
                Type = type;
            }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                context.Writer.Append("...");
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class VendorExtension : IParsingResultExtended
        {
            public VendorExtension(IParsingResult name, TemplateArgs arguments, IParsingResult type)
            {
                Name = name;
                Arguments = arguments;
                Type = type;
            }

            public TemplateArgs Arguments { get; private set; }

            public IParsingResult Name { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                context.Writer.Append(" ");
                Name.Demangle(context);
                Arguments?.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Arguments;
            }
        }
    }
}
