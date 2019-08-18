using System.Diagnostics;

namespace CxxDemangler.Parsers
{
    // <prefix> ::= <unqualified-name>
    //          ::= <prefix> <unqualified-name>
    //          ::= <template-prefix> <template-args>
    //          ::= <template-param>
    //          ::= <decltype>
    //          ::= <prefix> <data-member-prefix>
    //          ::= <substitution>
    internal class Prefix
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;
            IParsingResultExtended result = null;
            bool isResultTemplatePrefix = false;

            while (!context.Parser.IsEnd)
            {
                bool isResultTemplatePrefixNext = false;

                switch (context.Parser.Peek)
                {
                    case 'S':
                        {
                            IParsingResultExtended substitution = Substitution.Parse(context);

                            if (substitution == null)
                            {
                                context.Rewind(rewind);
                                return null;
                            }

                            result = substitution;
                        }
                        break;
                    case 'T':
                        {
                            IParsingResultExtended param = TemplateParam.Parse(context);

                            if (param == null)
                            {
                                context.Rewind(rewind);
                                return null;
                            }

                            result = AddToSubstitutionTable(context, param);
                            isResultTemplatePrefixNext = true;
                        }
                        break;
                    case 'D':
                        {
                            IParsingResultExtended decltype = Decltype.Parse(context);

                            if (decltype != null)
                            {
                                result = AddToSubstitutionTable(context, decltype);
                            }
                            else
                            {
                                IParsingResultExtended name = UnqualifiedName.Parse(context);

                                if (name == null)
                                {
                                    context.Rewind(rewind);
                                    return null;
                                }

                                if (result != null)
                                {
                                    result = AddToSubstitutionTable(context, new NestedName(result, name));
                                }
                                else
                                {
                                    result = AddToSubstitutionTable(context, name);
                                }
                                isResultTemplatePrefixNext = true;
                            }
                        }
                        break;
                    default:
                        if (context.Parser.Peek == 'I' && result != null && isResultTemplatePrefix)
                        {
                            TemplateArgs arguments = TemplateArgs.Parse(context);

                            if (arguments == null)
                            {
                                context.Rewind(rewind);
                                return null;
                            }

                            result = AddToSubstitutionTable(context, new Template(result, arguments));
                        }
                        else if (result != null && SourceName.StartsWith(context))
                        {
                            Debug.Assert(UnqualifiedName.StartsWith(context));
                            Debug.Assert(DataMemberPrefix.StartsWith(context));

                            IParsingResultExtended name = SourceName.Parse(context);

                            if (name == null)
                            {
                                context.Rewind(rewind);
                                return null;
                            }

                            if (context.Parser.VerifyString("M"))
                            {
                                result = AddToSubstitutionTable(context, new DataMember(result, name));
                            }
                            else
                            {
                                if (result != null)
                                {
                                    result = AddToSubstitutionTable(context, new NestedName(result, name));
                                }
                                else
                                {
                                    result = AddToSubstitutionTable(context, name);
                                }
                                isResultTemplatePrefixNext = true;
                            }
                        }
                        else if (UnqualifiedName.StartsWith(context))
                        {
                            IParsingResultExtended name = UnqualifiedName.Parse(context);

                            if (name == null)
                            {
                                context.Rewind(rewind);
                                return null;
                            }

                            if (result != null)
                            {
                                result = AddToSubstitutionTable(context, new NestedName(result, name));
                            }
                            else
                            {
                                result = AddToSubstitutionTable(context, name);
                            }
                            isResultTemplatePrefixNext = true;
                        }
                        else
                        {
                            if (result != null)
                            {
                                return result;
                            }

                            context.Rewind(rewind);
                            return null;
                        }
                        break;
                }
                isResultTemplatePrefix = isResultTemplatePrefixNext;
            }

            return result;
        }

        private static IParsingResultExtended AddToSubstitutionTable(ParsingContext context, IParsingResultExtended result)
        {
            context.SubstitutionTable.Add(result);
            return result;
        }

        internal class DataMember : IParsingResultExtended
        {
            public DataMember(IParsingResultExtended name, IParsingResult member)
            {
                Name = name;
                Member = member;
            }

            public IParsingResult Member { get; private set; }
            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Name.Demangle(context);
                Member.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return null;
            }
        }

        internal class NestedName : IParsingResultExtended
        {
            public NestedName(IParsingResultExtended previous, IParsingResultExtended name)
            {
                Previous = previous;
                Name = name;
            }

            public IParsingResultExtended Previous { get; private set; }

            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Previous.Demangle(context);
                context.Writer.Append("::");
                Name.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name.GetTemplateArgs() ?? Previous.GetTemplateArgs();
            }
        }

        internal class Template : IParsingResultExtended
        {
            public Template(IParsingResultExtended name, TemplateArgs arguments)
            {
                Name = name;
                Arguments = arguments;
            }

            public TemplateArgs Arguments { get; private set; }
            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Name.Demangle(context);
                Arguments.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Arguments;
            }
        }
    }
}
