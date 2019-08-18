using System.Collections.Generic;

namespace CxxDemangler.Parsers
{
    //   <unresolved-name> ::= [gs] <base-unresolved-name>                     # x or (with "gs") ::x
    //                     ::= sr <unresolved-type> <base-unresolved-name>     # T::x / decltype(p)::x
    //                     ::= srN <unresolved-type> <unresolved-qualifier-level>+ E <base-unresolved-name>
    //                                                                         # T::N::x /decltype(p)::N::x
    //                     ::= [gs] sr <unresolved-qualifier-level>+ E <base-unresolved-name>
    //                                                                         # A::x, N::y, A<T>::z; "gs" means leading "::"
    internal class UnresolvedName
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;
            IParsingResult name, type;
            List<IParsingResult> levels;

            if (context.Parser.VerifyString("gs"))
            {
                name = BaseUnresolvedName.Parse(context);
                if (name != null)
                {
                    return new Global(name);
                }
                if (context.Parser.VerifyString("sr"))
                {
                    levels = CxxDemangler.ParseList(UnresolvedQualifierLevel.Parse, context);
                    if (levels.Count > 0 && context.Parser.VerifyString("E"))
                    {
                        name = BaseUnresolvedName.Parse(context);
                        if (name != null)
                        {
                            return new GlobalNested2(levels, name);
                        }
                    }
                }
                context.Rewind(rewind);
                return null;
            }
            name = BaseUnresolvedName.Parse(context);
            if (name != null)
            {
                return name;
            }
            if (!context.Parser.VerifyString("sr"))
            {
                return null;
            }
            if (context.Parser.VerifyString("N"))
            {
                type = UnresolvedType.Parse(context);
                if (type != null)
                {
                    levels = CxxDemangler.ParseList(UnresolvedQualifierLevel.Parse, context);
                    if (levels.Count > 0 && context.Parser.VerifyString("E"))
                    {
                        name = BaseUnresolvedName.Parse(context);
                        if (name != null)
                        {
                            return new Nested1(type, levels, name);
                        }
                    }
                }
                context.Rewind(rewind);
                return null;
            }
            type = UnresolvedType.Parse(context);
            if (type != null)
            {
                name = BaseUnresolvedName.Parse(context);
                if (name != null)
                {
                    return new Nested1(type, new List<IParsingResult>(), name);
                }
                context.Rewind(rewind);
                return null;
            }

            levels = CxxDemangler.ParseList(UnresolvedQualifierLevel.Parse, context);
            if (levels.Count > 0 && context.Parser.VerifyString("E"))
            {
                name = BaseUnresolvedName.Parse(context);
                if (name != null)
                {
                    return new Nested2(levels, name);
                }
            }
            context.Rewind(rewind);
            return null;
        }

        internal class Global : IParsingResult
        {
            public Global(IParsingResult name)
            {
                Name = name;
            }

            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("::");
                Name.Demangle(context);
            }
        }

        internal class Nested1 : IParsingResult
        {
            public Nested1(IParsingResult type, IReadOnlyList<IParsingResult> levels, IParsingResult name)
            {
                Type = type;
                Levels = levels;
                Name = name;
            }

            public IParsingResult Type { get; private set; }

            public IReadOnlyList<IParsingResult> Levels { get; private set; }

            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Type.Demangle(context);
                foreach (IParsingResult level in Levels)
                {
                    context.Writer.Append("::");
                    level.Demangle(context);
                }
                Name.Demangle(context);
            }
        }

        internal class Nested2 : IParsingResult
        {
            public Nested2(IReadOnlyList<IParsingResult> levels, IParsingResult name)
            {
                Levels = levels;
                Name = name;
            }

            public IReadOnlyList<IParsingResult> Levels { get; private set; }

            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                foreach (IParsingResult level in Levels)
                {
                    context.Writer.Append("::");
                    level.Demangle(context);
                }
                Name.Demangle(context);
            }
        }

        internal class GlobalNested2 : IParsingResult
        {
            public GlobalNested2(IReadOnlyList<IParsingResult> levels, IParsingResult name)
            {
                Levels = levels;
                Name = name;
            }

            public IReadOnlyList<IParsingResult> Levels { get; private set; }

            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("::");
                foreach (IParsingResult level in Levels)
                {
                    context.Writer.Append("::");
                    level.Demangle(context);
                }
                Name.Demangle(context);
            }
        }
    }
}
