using System;
using System.Collections.Generic;
using System.Linq;

namespace CxxDemangler.Parsers
{
    // <bare-function-type> ::= <signature type>+
    //     # types are possible return type, then parameter types
    internal class BareFunctionType : IParsingResult, IDemangleAsInner
    {
        public BareFunctionType(IReadOnlyList<IParsingResult> types)
        {
            Types = types;
        }

        public IReadOnlyList<IParsingResult> Types { get; private set; }

        public static BareFunctionType Parse(ParsingContext context)
        {
            List<IParsingResult> types = CxxDemangler.ParseList(Type.Parse, context);

            if (types.Count > 0)
            {
                return new BareFunctionType(types);
            }

            return null;
        }

        public void Demangle(DemanglingContext context)
        {
            context.Inner.Push(this);
            Types[0].Demangle(context);
            if (context.Inner.Count > 0)
            {
                context.Writer.EnsureSpace();
                context.Inner.Pop().DemangleAsInner(context);
            }
        }

        public void DemangleAsInner(DemanglingContext context)
        {
            DemangleWithoutType(context);
        }

        public void DemangleWithType(DemanglingContext context)
        {
            Demangle(Types, context);
        }

        public void DemangleWithoutType(DemanglingContext context)
        {
            Demangle(Types.Skip(1), context);
        }

        public static void Demangle(IEnumerable<IParsingResult> types, DemanglingContext context)
        {
            // TODO: if ctx.options.no_params && stack.is_none() return;

            bool sawNeedsParentheses = false;
            Tuple<bool, bool> needsSpaceParentheses = context.Inner
                .DefaultIfEmpty(null)
                .Select(inner =>
                {
                    if (inner is PointerToMemberType)
                    {
                        return Tuple.Create(true, true);
                    }
                    else if (inner is Type.PointerTo || inner is Type.LvalueRef || inner is Type.RvalueRef)
                    {
                        return Tuple.Create(false, true);
                    }
                    return Tuple.Create(false, false);
                })
                .TakeWhile(t =>
                    {
                        if (sawNeedsParentheses)
                        {
                            return false;
                        }
                        else
                        {
                            sawNeedsParentheses |= t.Item2;
                            return true;
                        }
                    })
                .Aggregate((t1, t2) => Tuple.Create(t1.Item1 || t2.Item1, t1.Item2 || t2.Item2));
            bool needsSpace = needsSpaceParentheses.Item1;
            bool needsParenentheses = needsSpaceParentheses.Item2;

            if (needsParenentheses)
            {
                if (context.Writer.Last != '(' && context.Writer.Last != '*')
                {
                    needsSpace = true;
                }
                if (needsSpace)
                {
                    context.Writer.EnsureSpace();
                }
                context.Writer.Append("(");
            }

            List<IDemangleAsInner> newInner = new List<IDemangleAsInner>();

            while (context.Inner.Count > 0)
            {
                IDemangleAsInner inner = context.Inner.Pop();

                if (inner is Encoding.Function)
                {
                    newInner.Add(inner);
                }
                else
                {
                    inner.DemangleAsInner(context);
                }
            }
            foreach (IDemangleAsInner inner in newInner)
            {
                context.Inner.Push(inner);
            }

            if (needsParenentheses)
            {
                context.Writer.Append(")");
            }

            context.Writer.Append("(");

            // To maintain compatibility with libiberty, print `()` instead of
            // `(void)` for functions that take no arguments.
            if (types.Count() == 1)
            {
                StandardBuiltinType voidType = types.First() as StandardBuiltinType;

                if (voidType != null && voidType.Value == StandardBuiltinType.Values.Void)
                {
                    context.Writer.Append(")");
                    return;
                }
            }

            types.Demangle(context);
            context.Writer.Append(")");
        }
    }
}
