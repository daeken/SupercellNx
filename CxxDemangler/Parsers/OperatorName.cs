namespace CxxDemangler.Parsers
{
    // <operator-name> ::= nw	# new
    //                 ::= na	# new[]
    //                 ::= dl	# delete
    //                 ::= da	# delete[]
    //                 ::= ps   # + (unary)
    //                 ::= ng	# - (unary)
    //                 ::= ad	# & (unary)
    //                 ::= de	# * (unary)
    //                 ::= co	# ~
    //                 ::= pl	# +
    //                 ::= mi	# -
    //                 ::= ml	# *
    //                 ::= dv	# /
    //                 ::= rm	# %
    //                 ::= an	# &
    //                 ::= or	# |
    //                 ::= eo	# ^
    //                 ::= aS	# =
    //                 ::= pL	# +=
    //                 ::= mI	# -=
    //                 ::= mL	# *=
    //                 ::= dV	# /=
    //                 ::= rM	# %=
    //                 ::= aN	# &=
    //                 ::= oR	# |=
    //                 ::= eO	# ^=
    //                 ::= ls	# <<
    //                 ::= rs	# >>
    //                 ::= lS	# <<=
    //                 ::= rS	# >>=
    //                 ::= eq	# ==
    //                 ::= ne	# !=
    //                 ::= lt	# <
    //                 ::= gt	# >
    //                 ::= le	# <=
    //                 ::= ge	# >=
    //                 ::= nt	# !
    //                 ::= aa	# &&
    //                 ::= oo	# ||
    //                 ::= pp	# ++ (postfix in <expression> context)
    //                 ::= mm	# -- (postfix in <expression> context)
    //                 ::= cm	# ,
    //                 ::= pm	# ->*
    //                 ::= pt	# ->
    //                 ::= cl	# ()
    //                 ::= ix	# []
    //                 ::= qu	# ?
    //                 ::= cv <type>	# (cast)
    //                 ::= li <source-name>          # operator ""
    //                 ::= v <digit> <source-name>	# vendor extended operator
    internal class OperatorName
    {
        public static IParsingResultExtended Parse(ParsingContext context)
        {
            IParsingResultExtended simple = SimpleOperatorName.Parse(context);

            if (simple != null)
            {
                return simple;
            }

            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("cv"))
            {
                IParsingResultExtended type = Type.Parse(context);

                if (type == null)
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new Cast(type);
            }

            if (context.Parser.VerifyString("li"))
            {
                IParsingResultExtended name = SourceName.Parse(context);

                if (name == null)
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new Literal(name);
            }

            if (context.Parser.VerifyString("v"))
            {
                if (!char.IsDigit(context.Parser.Peek))
                {
                    context.Rewind(rewind);
                    return null;
                }

                int arity = context.Parser.Peek - '0';
                context.Parser.Position++;
                IParsingResultExtended name = SourceName.Parse(context);

                if (name == null)
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new VendorExtension(arity, name);
            }

            return null;
        }

        public static bool StartsWith(ParsingContext context)
        {
            char peek = context.Parser.Peek;

            return peek == 'c' || peek == 'l' || peek == 'v' || SimpleOperatorName.StartsWith(context);
        }

        internal class Cast : IParsingResultExtended
        {
            public Cast(IParsingResultExtended type)
            {
                Type = type;
            }

            public IParsingResultExtended Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                TemplateArgs args = Type.GetTemplateArgs();
                context.Writer.EnsureSpace();
                if (args != null)
                {
                    context.Stack.Push(args);
                }
                Type.Demangle(context);
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Type.GetTemplateArgs();
            }
        }

        internal class Literal : IParsingResultExtended
        {
            public Literal(IParsingResultExtended name)
            {
                Name = name;
            }

            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                Name.Demangle(context);
                context.Writer.Append("::operator \"\"");
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name.GetTemplateArgs();
            }
        }

        internal class VendorExtension : IParsingResultExtended
        {
            public VendorExtension(int arity, IParsingResultExtended name)
            {
                Arity = arity;
                Name = name;
            }

            public int Arity { get; private set; }

            public IParsingResultExtended Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                // TODO: no idea how this should be demangled...
                Name.Demangle(context);
                context.Writer.Append($"::operator {Arity}");
            }

            public TemplateArgs GetTemplateArgs()
            {
                return Name.GetTemplateArgs();
            }
        }
    }
}
