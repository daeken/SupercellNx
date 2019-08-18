using System;
using System.Collections.Generic;
using System.Reflection;

namespace CxxDemangler.Parsers
{
    internal class DictionaryParser<T>
    {
        private static HashSet<char> startingLetters = new HashSet<char>();
        private static Dictionary<string, T> mappings = new Dictionary<string, T>();
        private static Dictionary<T, string> demangledText = new Dictionary<T, string>();

        static DictionaryParser()
        {
            System.Type type = typeof(T);

            foreach (object enumValue in Enum.GetValues(type))
            {
                MemberInfo memberInfo = type.GetMember(enumValue.ToString())[0];
                DictionaryValueAttribute value = (DictionaryValueAttribute)memberInfo.GetCustomAttribute(typeof(DictionaryValueAttribute), false);

                mappings.Add(value.Input, (T)enumValue);
                demangledText.Add((T)enumValue, value.Output);
                startingLetters.Add(value.Input[0]);
            }
        }

        public static bool Parse(ParsingContext context, out T parsed)
        {
            foreach (KeyValuePair<string, T> value in mappings)
            {
                if (context.Parser.VerifyString(value.Key))
                {
                    parsed = value.Value;
                    return true;
                }
            }

            parsed = default(T);
            return false;
        }

        public static bool StartsWith(ParsingContext context)
        {
            return startingLetters.Contains(context.Parser.Peek);
        }

        public static void Demangle(T value, DemanglingContext context)
        {
            context.Writer.Append(demangledText[value]);
        }
    }
}
