using CxxDemangler.Parsers;
using System.Collections.Generic;

namespace CxxDemangler
{
    /// <summary>
    /// Static class that provides C++ linker symbol demangler functionality.
    /// </summary>
    public static class CxxDemangler
    {
        internal delegate IParsingResult ParsingFunction(ParsingContext context);

        /// <summary>
        /// Demangles the specified C++ linker symbol input.
        /// </summary>
        /// <param name="input">C++ linker symbol input</param>
        /// <param name="gccCompatibleDemangle">if set to <c>true</c> result will be GCC compatible.</param>
        /// <returns>
        /// Demangled C++ linker symbol input.
        /// </returns>
        /// <remarks>
        /// If input is not in correct format, original input is returned.
        /// </remarks>
        public static string Demangle(string input, bool gccCompatibleDemangle = true)
        {
            ParsingContext parsingContext = CreateContext(input);
            IParsingResult result = Parse(parsingContext);

            if (result != null)
            {
                DemanglingContext demanglingContext = DemanglingContext.Create(parsingContext, gccCompatibleDemangle);

                result.Demangle(demanglingContext);
                return demanglingContext.Writer.Text;
            }

            return input;
        }

        internal static IParsingResult Parse(ParsingContext context)
        {
            return MangledName.Parse(context);
        }

        internal static List<IParsingResult> ParseList(ParsingFunction parse, ParsingContext context)
        {
            List<IParsingResult> results = new List<IParsingResult>();

            while (true)
            {
                IParsingResult result = parse(context);

                if (result == null)
                {
                    break;
                }

                results.Add(result);
            }

            return results;
        }

        internal static ParsingContext CreateContext(string input)
        {
            SubstitutionTable table = new SubstitutionTable();
            SimpleStringParser parser = new SimpleStringParser(input);

            return new ParsingContext()
            {
                Parser = parser,
                SubstitutionTable = table,
            };
        }
    }
}
