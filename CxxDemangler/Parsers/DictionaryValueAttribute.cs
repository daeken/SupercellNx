using System;

namespace CxxDemangler.Parsers
{
    internal class DictionaryValueAttribute : Attribute
    {
        public DictionaryValueAttribute(string input, string output)
        {
            Input = input;
            Output = output;
        }

        public string Input { get; set; }

        public string Output { get; set; }
    }
}
