using System.Diagnostics;

namespace CxxDemangler.Parsers
{
    // <array-type> ::= A <positive dimension number> _ <element type>
    //              ::= A[< dimension expression >] _<element type>
    internal abstract class ArrayType : IParsingResultExtended, IDemangleAsInner
    {
        public ArrayType(IParsingResult type)
        {
            Type = type;
        }

        public IParsingResult Type { get; private set; }

        public static IParsingResultExtended Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("A"))
            {
                return null;
            }

            int number;
            IParsingResult type;

            if (context.Parser.ParseNumber(out number))
            {
                Debug.Assert(number >= 0);
                if (context.Parser.VerifyString("_"))
                {
                    type = Parsers.Type.Parse(context);
                    if (type != null)
                    {
                        return new DimensionNumber(number, type);
                    }
                }
                context.Rewind(rewind);
                return null;
            }

            IParsingResult expression = Expression.Parse(context);

            if (expression != null)
            {
                if (context.Parser.VerifyString("_"))
                {
                    type = Parsers.Type.Parse(context);
                    if (type != null)
                    {
                        return new DimensionExpression(expression, type);
                    }
                }
                context.Rewind(rewind);
                return null;
            }

            if (context.Parser.VerifyString("_"))
            {
                type = Parsers.Type.Parse(context);
                if (type != null)
                {
                    return new NoDimension(type);
                }
            }

            context.Rewind(rewind);
            return null;
        }

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
            bool innerIsArray = false;

            while (context.Inner.Count > 0)
            {
                IDemangleAsInner inner = context.Inner.Pop();

                innerIsArray = inner is ArrayType;
                if (!innerIsArray)
                {
                    context.Writer.EnsureSpace();
                    context.Writer.Append("(");
                }
                inner.DemangleAsInner(context);
                if (!innerIsArray)
                {
                    context.Writer.Append(")");
                }
            }
            if (!innerIsArray)
            {
                context.Writer.EnsureSpace();
            }
            context.Writer.Append("[");
            DemangleSize(context);
            context.Writer.Append("]");
        }

        public TemplateArgs GetTemplateArgs()
        {
            return null;
        }

        protected abstract void DemangleSize(DemanglingContext context);

        internal class DimensionExpression : ArrayType
        {
            public DimensionExpression(IParsingResult expression, IParsingResult type)
                : base(type)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            protected override void DemangleSize(DemanglingContext context)
            {
                Expression.Demangle(context);
            }
        }

        internal class DimensionNumber : ArrayType
        {
            public DimensionNumber(int number, IParsingResult type)
                : base(type)
            {
                Number = number;
            }

            public int Number { get; private set; }

            protected override void DemangleSize(DemanglingContext context)
            {
                context.Writer.Append($"{Number}");
            }
        }

        internal class NoDimension : ArrayType
        {
            public NoDimension(IParsingResult type)
                : base(type)
            {
            }

            protected override void DemangleSize(DemanglingContext context)
            {
            }
        }
    }
}
