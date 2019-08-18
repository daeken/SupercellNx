using System;
using System.Collections.Generic;

namespace CxxDemangler.Parsers
{
    // <expression> ::= <unary operator-name> <expression>
    //              ::= <binary operator-name> <expression> <expression>
    //              ::= <ternary operator-name> <expression> <expression> <expression>
    //              ::= pp_ <expression>                                     # prefix ++
    //              ::= mm_ <expression>                                     # prefix --
    //              ::= cl <expression>+ E                                   # expression (expr-list), call
    //              ::= cv <type> <expression>                               # type (expression), conversion with one argument
    //              ::= cv <type> _ <expression>* E                          # type (expr-list), conversion with other than one argument
    //              ::= tl <type> <expression>* E                            # type {expr-list}, conversion with braced-init-list argument
    //              ::= il <expression>* E                                   # {expr-list}, braced-init-list in any other context
    //              ::= [gs] nw <expression>* _ <type> E                     # new (expr-list) type
    //              ::= [gs] nw <expression>* _ <type> <initializer>         # new (expr-list) type (init)
    //              ::= [gs] na <expression>* _ <type> E                     # new[] (expr-list) type
    //              ::= [gs] na <expression>* _ <type> <initializer>         # new[] (expr-list) type (init)
    //              ::= [gs] dl <expression>                                 # delete expression
    //              ::= [gs] da <expression>                                 # delete[] expression
    //              ::= dc <type> <expression>                               # dynamic_cast<type> (expression)
    //              ::= sc <type> <expression>                               # static_cast<type> (expression)
    //              ::= cc <type> <expression>                               # const_cast<type> (expression)
    //              ::= rc <type> <expression>                               # reinterpret_cast<type> (expression)
    //              ::= ti <type>                                            # typeid (type)
    //              ::= te <expression>                                      # typeid (expression)
    //              ::= st <type>                                            # sizeof (type)
    //              ::= sz <expression>                                      # sizeof (expression)
    //              ::= at <type>                                            # alignof (type)
    //              ::= az <expression>                                      # alignof (expression)
    //              ::= nx <expression>                                      # noexcept (expression)
    //              ::= <template-param>
    //              ::= <function-param>
    //              ::= dt <expression> <unresolved-name>                    # expr.name
    //              ::= pt <expression> <unresolved-name>                    # expr->name
    //              ::= ds <expression> <expression>                         # expr.*expr
    //              ::= sZ <template-param>                                  # sizeof...(T), size of a template parameter pack
    //              ::= sZ <function-param>                                  # sizeof...(parameter), size of a function parameter pack
    //              ::= sP <template-arg>* E                                 # sizeof...(T), size of a captured template parameter pack from an alias template
    //              ::= sp <expression>                                      # expression..., pack expansion
    //              ::= tw <expression>                                      # throw expression
    //              ::= tr                                                   # throw with no operand (rethrow)
    //              ::= <unresolved-name>                                    # f(p), N::f(p), ::f(p),
    //                                                                       # freestanding dependent name (e.g., T::x),
    //                                                                       # objectless nonstatic member reference
    //              ::= <expr-primary>
    internal class Expression
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("pp_"))
            {
                return Parse<PrefixInc>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("mm_"))
            {
                return Parse<PrefixDec>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("cl"))
            {
                return Parse<Call>(rewind, context, Expression.Parse, ZeroOrMore(Expression.Parse));
            }
            if (context.Parser.VerifyString("cv"))
            {
                IParsingResult type = Type.Parse(context);

                if (type != null)
                {
                    if (context.Parser.VerifyString("_"))
                    {
                        List<IParsingResult> expressions = CxxDemangler.ParseList(Expression.Parse, context);

                        if (context.Parser.VerifyString("E"))
                        {
                            return new ConversionMany(type, expressions);
                        }
                    }
                    else
                    {
                        IParsingResult expression = Expression.Parse(context);

                        if (expression != null)
                        {
                            return new ConversionOne(type, expression);
                        }
                    }
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("tl"))
            {
                return ParseWithEnd<ConversionBraced>(rewind, context, Type.Parse, ZeroOrMore(Expression.Parse));
            }
            if (context.Parser.VerifyString("il"))
            {
                return ParseWithEnd<BracedInitList>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("dc"))
            {
                return Parse<DynamicCast>(rewind, context, Type.Parse, Expression.Parse);
            }
            if (context.Parser.VerifyString("sc"))
            {
                return Parse<StaticCast>(rewind, context, Type.Parse, Expression.Parse);
            }
            if (context.Parser.VerifyString("cc"))
            {
                return Parse<ConstCast>(rewind, context, Type.Parse, Expression.Parse);
            }
            if (context.Parser.VerifyString("rc"))
            {
                return Parse<ReinterpretCast>(rewind, context, Type.Parse, Expression.Parse);
            }
            if (context.Parser.VerifyString("ti"))
            {
                return Parse<TypeIdType>(rewind, context, Type.Parse);
            }
            if (context.Parser.VerifyString("te"))
            {
                return Parse<TypeIdExpression>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("st"))
            {
                return Parse<SizeOfType>(rewind, context, Type.Parse);
            }
            if (context.Parser.VerifyString("sz"))
            {
                return Parse<SizeOfExpression>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("at"))
            {
                return Parse<AlignOfType>(rewind, context, Type.Parse);
            }
            if (context.Parser.VerifyString("az"))
            {
                return Parse<AlignOfExpression>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("nx"))
            {
                return Parse<Noexcept>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("dt"))
            {
                return Parse<Member>(rewind, context, Expression.Parse, UnresolvedName.Parse);
            }
            if (context.Parser.VerifyString("pt"))
            {
                return Parse<DeferMember>(rewind, context, Expression.Parse, UnresolvedName.Parse);
            }
            if (context.Parser.VerifyString("ds"))
            {
                return Parse<PointerToMember>(rewind, context, Expression.Parse, Expression.Parse);
            }
            if (context.Parser.VerifyString("sZ"))
            {
                IParsingResult param = TemplateParam.Parse(context);

                if (param != null)
                {
                    return new SizeOfTemplatepack(param);
                }
                param = FunctionParam.Parse(context);
                if (param != null)
                {
                    return new SizeOfFunctionPack(param);
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("sP"))
            {
                return ParseWithEnd<SizeofCapturedTemplatePack>(rewind, context, ZeroOrMore(TemplateArg.Parse));
            }
            if (context.Parser.VerifyString("sp"))
            {
                return Parse<PackExpansion>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("tw"))
            {
                return Parse<Throw>(rewind, context, Expression.Parse);
            }
            if (context.Parser.VerifyString("tr"))
            {
                return new Retrow();
            }
            if (context.Parser.VerifyString("gs"))
            {
                return CanBeGlobal(rewind, context, true);
            }

            IParsingResult result = CanBeGlobal(rewind, context, false) ?? TemplateParam.Parse(context) ?? FunctionParam.Parse(context)
                ?? UnresolvedName.Parse(context) ?? ExprPrimary.Parse(context);

            if (result != null)
            {
                return result;
            }

            IParsingResult operatorName = OperatorName.Parse(context);

            if (operatorName != null)
            {
                IParsingResult first = Expression.Parse(context);

                if (first != null)
                {
                    IParsingResult second = Expression.Parse(context);

                    if (second != null)
                    {
                        IParsingResult third = Expression.Parse(context);

                        if (third != null)
                        {
                            return new Ternary(operatorName, first, second, third);
                        }
                        else
                        {
                            return new Binary(operatorName, first, second);
                        }
                    }
                    else
                    {
                        return new Unary(operatorName, first);
                    }
                }
                context.Rewind(rewind);
                return null;
            }
            return null;
        }

        private static IParsingResult CanBeGlobal(RewindState rewind, ParsingContext context, bool isGlobal)
        {
            if (context.Parser.VerifyString("nw"))
            {
                List<IParsingResult> expressions = CxxDemangler.ParseList(Expression.Parse, context);

                if (context.Parser.VerifyString("_"))
                {
                    IParsingResult type = Type.Parse(context);

                    if (type != null)
                    {
                        if (context.Parser.VerifyString("E"))
                        {
                            if (isGlobal)
                            {
                                return new GlobalNew(expressions, type);
                            }
                            else
                            {
                                return new New(expressions, type);
                            }
                        }
                        else
                        {
                            IParsingResult initializer = Initializer.Parse(context);

                            if (initializer != null)
                            {
                                if (isGlobal)
                                {
                                    return new GlobalNew(expressions, type, initializer);
                                }
                                else
                                {
                                    return new New(expressions, type, initializer);
                                }
                            }
                        }
                    }
                }
            }
            else if (context.Parser.VerifyString("na"))
            {
                List<IParsingResult> expressions = CxxDemangler.ParseList(Expression.Parse, context);

                if (context.Parser.VerifyString("_"))
                {
                    IParsingResult type = Type.Parse(context);

                    if (type != null)
                    {
                        if (context.Parser.VerifyString("E"))
                        {
                            if (isGlobal)
                            {
                                return new GlobalNewArray(expressions, type);
                            }
                            else
                            {
                                return new NewArray(expressions, type);
                            }
                        }
                        else
                        {
                            IParsingResult initializer = Initializer.Parse(context);

                            if (initializer != null)
                            {
                                if (isGlobal)
                                {
                                    return new GlobalNewArray(expressions, type, initializer);
                                }
                                else
                                {
                                    return new NewArray(expressions, type, initializer);
                                }
                            }
                        }
                    }
                }
            }
            else if (context.Parser.VerifyString("dl"))
            {
                IParsingResult expression = Expression.Parse(context);

                if (expression != null)
                {
                    if (isGlobal)
                    {
                        return new GlobalDelete(expression);
                    }
                    else
                    {
                        return new Delete(expression);
                    }
                }
            }
            else if (context.Parser.VerifyString("da"))
            {
                IParsingResult expression = Expression.Parse(context);

                if (expression != null)
                {
                    if (isGlobal)
                    {
                        return new GlobalDeleteArray(expression);
                    }
                    else
                    {
                        return new DeleteArray(expression);
                    }
                }
            }
            context.Rewind(rewind);
            return null;
        }

        private static Func<ParsingContext, List<IParsingResult>> ZeroOrMore(CxxDemangler.ParsingFunction parser)
        {
            return (ParsingContext context) =>
            {
                return CxxDemangler.ParseList(parser, context);
            };
        }

        private static IParsingResult Parse<T>(RewindState rewind, ParsingContext context, params Func<ParsingContext, object>[] paramsParse)
            where T : IParsingResult
        {
            object[] paramsValue = new object[paramsParse.Length];

            for (int i = 0; i < paramsParse.Length; i++)
            {
                paramsValue[i] = paramsParse[i](context);
                if (paramsValue[i] == null)
                {
                    context.Rewind(rewind);
                    return null;
                }
            }
            return (T)Activator.CreateInstance(typeof(T), paramsValue);
        }

        private static IParsingResult ParseWithEnd<T>(RewindState rewind, ParsingContext context, params Func<ParsingContext, object>[] paramsParse)
            where T : IParsingResult
        {
            IParsingResult result = Parse<T>(rewind, context, paramsParse);

            if (result != null && context.Parser.VerifyString("E"))
            {
                return result;
            }
            context.Rewind(rewind);
            return null;
        }

        internal class Unary : IParsingResult
        {
            public Unary(IParsingResult operatorName, IParsingResult expression)
            {
                OperatorName = operatorName;
                Expression = expression;
            }

            public IParsingResult OperatorName { get; private set; }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                OperatorName.Demangle(context);
                context.Writer.Append(" ");
                Expression.Demangle(context);
            }
        }

        internal class Binary : IParsingResult
        {
            public Binary(IParsingResult operatorName, IParsingResult firstExpression, IParsingResult secondExpression)
            {
                OperatorName = operatorName;
                FirstExpression = firstExpression;
                SecondExpression = secondExpression;
            }

            public IParsingResult OperatorName { get; private set; }

            public IParsingResult FirstExpression { get; private set; }

            public IParsingResult SecondExpression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("(");
                FirstExpression.Demangle(context);
                context.Writer.Append(")");
                OperatorName.Demangle(context);
                context.Writer.Append("(");
                SecondExpression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class Ternary : IParsingResult
        {
            public Ternary(IParsingResult operatorName, IParsingResult firstExpression, IParsingResult secondExpression, IParsingResult thirdExpression)
            {
                OperatorName = operatorName;
                FirstExpression = firstExpression;
                SecondExpression = secondExpression;
                ThirdExpression = thirdExpression;
            }

            public IParsingResult OperatorName { get; private set; }

            public IParsingResult FirstExpression { get; private set; }

            public IParsingResult SecondExpression { get; private set; }

            public IParsingResult ThirdExpression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                SimpleOperatorName question = OperatorName as SimpleOperatorName;

                if (question.Value == SimpleOperatorName.Values.Question)
                {
                    FirstExpression.Demangle(context);
                    context.Writer.Append(" ? ");
                    SecondExpression.Demangle(context);
                    context.Writer.Append(" : ");
                    ThirdExpression.Demangle(context);
                }
                else
                {
                    // Nonsensical ternary operator? Just print it like a function call,
                    // I suppose...
                    //
                    // TODO: should we detect and reject this during parsing?
                    OperatorName.Demangle(context);
                    context.Writer.Append("(");
                    FirstExpression.Demangle(context);
                    context.Writer.Append(", ");
                    SecondExpression.Demangle(context);
                    context.Writer.Append(", ");
                    ThirdExpression.Demangle(context);
                    context.Writer.Append(")");
                }
            }
        }

        internal class PrefixInc : IParsingResult
        {
            public PrefixInc(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("++");
                Expression.Demangle(context);
            }
        }

        internal class PrefixDec : IParsingResult
        {
            public PrefixDec(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("--");
                Expression.Demangle(context);
            }
        }

        internal class Call : IParsingResult
        {
            public Call(IParsingResult expression, IReadOnlyList<IParsingResult> arguments)
            {
                Expression = expression;
                Arguments = arguments;
            }

            public IParsingResult Expression { get; private set; }

            public IReadOnlyList<IParsingResult> Arguments { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("(");
                Expression.Demangle(context);
                context.Writer.Append(")(");
                Arguments.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class ConversionOne : IParsingResult
        {
            public ConversionOne(IParsingResult type, IParsingResult expression)
            {
                Type = type;
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                context.Writer.Append("(");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class ConversionMany : IParsingResult
        {
            public ConversionMany(IParsingResult type, IReadOnlyList<IParsingResult> expressions)
            {
                Type = type;
                Expressions = expressions;
            }

            public IReadOnlyList<IParsingResult> Expressions { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                context.Writer.Append("(");
                Expressions.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class ConversionBraced : IParsingResult
        {
            public ConversionBraced(IParsingResult type, IReadOnlyList<IParsingResult> expressions)
            {
                Type = type;
                Expressions = expressions;
            }

            public IReadOnlyList<IParsingResult> Expressions { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                context.Writer.Append("{");
                Expressions.Demangle(context);
                context.Writer.Append("}");
            }
        }

        internal class BracedInitList : IParsingResult
        {
            public BracedInitList(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("{");
                Expression.Demangle(context);
                context.Writer.Append("}");
            }
        }

        internal class New : IParsingResult
        {
            public New(IReadOnlyList<IParsingResult> expressions, IParsingResult type, IParsingResult initializer = null)
            {
                Expressions = expressions;
                Type = type;
                Initializer = initializer;
            }

            public IReadOnlyList<IParsingResult> Expressions { get; private set; }

            public IParsingResult Initializer { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("new (");
                Expressions.Demangle(context);
                context.Writer.Append(") ");
                Type.Demangle(context);
                Initializer?.Demangle(context);
            }
        }

        internal class GlobalNew : IParsingResult
        {
            public GlobalNew(IReadOnlyList<IParsingResult> expressions, IParsingResult type, IParsingResult initializer = null)
            {
                Expressions = expressions;
                Type = type;
                Initializer = initializer;
            }

            public IReadOnlyList<IParsingResult> Expressions { get; private set; }

            public IParsingResult Initializer { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("::new (");
                Expressions.Demangle(context);
                context.Writer.Append(") ");
                Type.Demangle(context);
                Initializer?.Demangle(context);
            }
        }

        internal class NewArray : IParsingResult
        {
            public NewArray(IReadOnlyList<IParsingResult> expressions, IParsingResult type, IParsingResult initializer = null)
            {
                Expressions = expressions;
                Type = type;
                Initializer = initializer;
            }

            public IReadOnlyList<IParsingResult> Expressions { get; private set; }

            public IParsingResult Initializer { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("new[] (");
                Expressions.Demangle(context);
                context.Writer.Append(") ");
                Type.Demangle(context);
                Initializer?.Demangle(context);
            }
        }

        internal class GlobalNewArray : IParsingResult
        {
            public GlobalNewArray(IReadOnlyList<IParsingResult> expressions, IParsingResult type, IParsingResult initializer = null)
            {
                Expressions = expressions;
                Type = type;
                Initializer = initializer;
            }

            public IReadOnlyList<IParsingResult> Expressions { get; private set; }

            public IParsingResult Initializer { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("::new[] (");
                Expressions.Demangle(context);
                context.Writer.Append(") ");
                Type.Demangle(context);
                Initializer?.Demangle(context);
            }
        }

        internal class Delete : IParsingResult
        {
            public Delete(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("delete ");
                Expression.Demangle(context);
            }
        }

        internal class GlobalDelete : IParsingResult
        {
            public GlobalDelete(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("::delete ");
                Expression.Demangle(context);
            }
        }

        internal class DeleteArray : IParsingResult
        {
            public DeleteArray(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("delete[] ");
                Expression.Demangle(context);
            }
        }

        internal class GlobalDeleteArray : IParsingResult
        {
            public GlobalDeleteArray(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("::delete[] ");
                Expression.Demangle(context);
            }
        }

        internal class DynamicCast : IParsingResult
        {
            public DynamicCast(IParsingResult type, IParsingResult expression)
            {
                Type = type;
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("dynamic_cast<");
                Type.Demangle(context);
                context.Writer.Append(">(");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class StaticCast : IParsingResult
        {
            public StaticCast(IParsingResult type, IParsingResult expression)
            {
                Type = type;
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("static_cast<");
                Type.Demangle(context);
                context.Writer.Append(">(");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class ConstCast : IParsingResult
        {
            public ConstCast(IParsingResult type, IParsingResult expression)
            {
                Type = type;
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("const_cast<");
                Type.Demangle(context);
                context.Writer.Append(">(");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class ReinterpretCast : IParsingResult
        {
            public ReinterpretCast(IParsingResult type, IParsingResult expression)
            {
                Type = type;
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("reinterpret_cast<");
                Type.Demangle(context);
                context.Writer.Append(">(");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class TypeIdType : IParsingResult
        {
            public TypeIdType(IParsingResult type)
            {
                Type = type;
            }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("typeid (");
                Type.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class TypeIdExpression : IParsingResult
        {
            public TypeIdExpression(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("typeid (");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class SizeOfType : IParsingResult
        {
            public SizeOfType(IParsingResult type)
            {
                Type = type;
            }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("sizeof (");
                Type.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class SizeOfExpression : IParsingResult
        {
            public SizeOfExpression(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("sizeof (");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class AlignOfType : IParsingResult
        {
            public AlignOfType(IParsingResult type)
            {
                Type = type;
            }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("alignof (");
                Type.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class AlignOfExpression : IParsingResult
        {
            public AlignOfExpression(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("alignof (");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class Noexcept : IParsingResult
        {
            public Noexcept(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("noexcept (");
                Expression.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class Member : IParsingResult
        {
            public Member(IParsingResult expression, IParsingResult name)
            {
                Expression = expression;
                Name = name;
            }

            public IParsingResult Expression { get; private set; }
            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Expression.Demangle(context);
                context.Writer.Append(".");
                Name.Demangle(context);
            }
        }

        internal class DeferMember : IParsingResult
        {
            public DeferMember(IParsingResult expression, IParsingResult name)
            {
                Expression = expression;
                Name = name;
            }

            public IParsingResult Expression { get; private set; }

            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Expression.Demangle(context);
                context.Writer.Append("->");
                Name.Demangle(context);
            }
        }

        internal class PointerToMember : IParsingResult
        {
            public PointerToMember(IParsingResult expression, IParsingResult expression2)
            {
                Expression = expression;
                Expression2 = expression2;
            }

            public IParsingResult Expression { get; private set; }

            public IParsingResult Expression2 { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Expression.Demangle(context);
                context.Writer.Append(".*");
                Expression2.Demangle(context);
            }
        }

        internal class SizeOfTemplatepack : IParsingResult
        {
            public SizeOfTemplatepack(IParsingResult parameter)
            {
                Parameter = parameter;
            }

            public IParsingResult Parameter { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("sizeof...(");
                Parameter.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class SizeOfFunctionPack : IParsingResult
        {
            public SizeOfFunctionPack(IParsingResult parameter)
            {
                Parameter = parameter;
            }

            public IParsingResult Parameter { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("sizeof...(");
                Parameter.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class SizeofCapturedTemplatePack : IParsingResult
        {
            public SizeofCapturedTemplatePack(IReadOnlyList<IParsingResult> arguments)
            {
                Arguments = arguments;
            }

            public IReadOnlyList<IParsingResult> Arguments { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("sizeof...(");
                Arguments.Demangle(context);
                context.Writer.Append(")");
            }
        }

        internal class PackExpansion : IParsingResult
        {
            public PackExpansion(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Expression.Demangle(context);
                context.Writer.Append("...");
            }
        }

        internal class Throw : IParsingResult
        {
            public Throw(IParsingResult expression)
            {
                Expression = expression;
            }

            public IParsingResult Expression { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("throw ");
                Expression.Demangle(context);
            }
        }

        internal class Retrow : IParsingResult
        {
            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("throw");
            }
        }
    }
}
