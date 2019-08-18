using System;
using System.Collections.Generic;

namespace CxxDemangler
{
    internal interface IArgumentScope
    {
        IParsingResult GetFunctionArg(int scope);

        IParsingResult GetTemplateArg(int number);
    }

    internal struct DemanglingContext
    {
        public struct TemplateArgsStack
        {
            public class MyNullable<T>
            {
                public T Value { get; set; }
            }

            public struct SimpleStack
            {
                public IArgumentScope Value;

                public MyNullable<SimpleStack> Previous;
            }

            public MyNullable<SimpleStack> Stack { get; private set; }

            /// <summary>
            /// Pushes value on the stack.
            /// Stack change is only valid for current variable lifetime since everything is allocated on stack.
            /// </summary>
            /// <param name="value">Value to be pushed on stack.</param>
            public void Push(IArgumentScope value)
            {
                SimpleStack newStack = new SimpleStack
                {
                    Previous = null,
                    Value = value,
                };
                Stack = new MyNullable<SimpleStack>()
                {
                    Value = newStack,
                };
            }

            public IParsingResult GetFunctionArg(int scope)
            {
                foreach (IArgumentScope argumentScope in Enumerate())
                {
                    IParsingResult arg = argumentScope.GetFunctionArg(scope);

                    if (arg != null)
                    {
                        return arg;
                    }
                }
                return null;
            }

            public IParsingResult GetTemplateArg(int number)
            {
                foreach (IArgumentScope argumentScope in Enumerate())
                {
                    IParsingResult arg = argumentScope.GetTemplateArg(number);

                    if (arg != null)
                    {
                        return arg;
                    }
                }
                return null;
            }

            public IEnumerable<IArgumentScope> Enumerate()
            {
                MyNullable<SimpleStack> head = Stack;

                while (head != null)
                {
                    yield return head.Value.Value;
                    head = head.Value.Previous;
                }
            }
        }

        public SimpleStringWriter Writer { get; private set; }

        public Stack<IDemangleAsInner> Inner { get; private set; }

        public SubstitutionTable SubstitutionTable { get; private set; }

        public TemplateArgsStack Stack;

        public bool GccCompatibleDemangle { get; private set; }

        public static DemanglingContext Create(ParsingContext parsingContext, bool gccCompatibleDemangle)
        {
            return new DemanglingContext()
            {
                Writer = new SimpleStringWriter(),
                Inner = new Stack<IDemangleAsInner>(),
                SubstitutionTable = parsingContext.SubstitutionTable,
                GccCompatibleDemangle = gccCompatibleDemangle,
            };
        }
    }

    internal static class DemanglerExtensions
    {
        public static void Demangle(this IEnumerable<IParsingResult> elements, DemanglingContext context, string separator = ", ")
        {
            bool needSeparator = false;

            foreach (IParsingResult element in elements)
            {
                if (needSeparator)
                {
                    context.Writer.Append(separator);
                }
                element.Demangle(context);
                needSeparator = true;
            }
        }
    }
}
