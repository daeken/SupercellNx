using CxxDemangler.Parsers;

namespace CxxDemangler
{
    internal interface IParsingResult
    {
        void Demangle(DemanglingContext context);
    }

    internal interface IParsingResultExtended : IParsingResult
    {
        TemplateArgs GetTemplateArgs();
    }
}
