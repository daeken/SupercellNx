namespace CxxDemangler.Parsers
{
    // <template-template-param> ::= <template-param>
    //                           ::= <substitution>
    internal class TemplateTemplateParam : IParsingResultExtended
    {
        public TemplateTemplateParam(IParsingResultExtended parameter)
        {
            Parameter = parameter;
        }

        public IParsingResultExtended Parameter { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            IParsingResultExtended substitution = Substitution.Parse(context);

            if (substitution != null)
            {
                return substitution;
            }

            IParsingResultExtended parameter = TemplateParam.Parse(context);

            if (parameter != null)
            {
                IParsingResultExtended result = new TemplateTemplateParam(parameter);
                context.SubstitutionTable.Add(result);
                return result;
            }
            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            Parameter.Demangle(context);
        }

        public TemplateArgs GetTemplateArgs()
        {
            return Parameter.GetTemplateArgs();
        }
    }
}
