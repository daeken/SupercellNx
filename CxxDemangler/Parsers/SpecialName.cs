namespace CxxDemangler.Parsers
{
    // <special-name> ::= TV <type>	# virtual table
    //        ::= TT <type>	# VTT structure (construction vtable index)
    //        ::= TI <type>	# typeinfo structure
    //        ::= TS <type>	# typeinfo name (null-terminated byte string)
    internal class SpecialName
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("TV"))
            {
                IParsingResult type = Type.Parse(context);

                if (type != null)
                {
                    return new VirtualTable(type);
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("TT"))
            {
                IParsingResult type = Type.Parse(context);

                if (type != null)
                {
                    return new Vtt(type);
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("TI"))
            {
                IParsingResult type = Type.Parse(context);

                if (type != null)
                {
                    return new TypeInfo(type);
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("TS"))
            {
                IParsingResult type = Type.Parse(context);

                if (type != null)
                {
                    return new TypeInfoName(type);
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("Tc"))
            {
                IParsingResult thisOffset = CallOffset.Parse(context);

                if (thisOffset != null)
                {
                    IParsingResult resultOffset = CallOffset.Parse(context);

                    if (resultOffset != null)
                    {
                        IParsingResult encoding = Encoding.Parse(context);

                        if (encoding != null)
                        {
                            return new VirtualOverrideThunkCovariant(thisOffset, resultOffset, encoding);
                        }
                    }
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("GV"))
            {
                IParsingResult name = Name.Parse(context);

                if (name != null)
                {
                    return new Guard(name);
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("GR"))
            {
                IParsingResult name = Name.Parse(context);

                if (name != null)
                {
                    int index;

                    if (!context.Parser.ParseNumberBase36(out index))
                    {
                        index = -1;
                    }
                    index++;
                    if (context.Parser.VerifyString("_"))
                    {
                        return new GuardTemporary(name, index);
                    }
                }
                context.Rewind(rewind);
                return null;
            }
            if (context.Parser.VerifyString("T"))
            {
                IParsingResult offset = CallOffset.Parse(context);

                if (offset != null)
                {
                    IParsingResult encoding = Encoding.Parse(context);

                    if (encoding != null)
                    {
                        return new VirtualOverrideThunk(offset, encoding);
                    }
                }
                context.Rewind(rewind);
                return null;
            }
            return null;
        }

        internal class VirtualTable : IParsingResult
        {
            public VirtualTable(IParsingResult type)
            {
                Type = type;
            }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                if (context.GccCompatibleDemangle)
                {
                    context.Writer.Append("vtable for ");
                    Type.Demangle(context);
                }
                else
                {
                    context.Writer.Append("{vtable(");
                    Type.Demangle(context);
                    context.Writer.Append(");");
                }
            }
        }

        internal class Vtt : IParsingResult
        {
            public Vtt(IParsingResult type)
            {
                Type = type;
            }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                if (context.GccCompatibleDemangle)
                {
                    context.Writer.Append("VTT for ");
                    Type.Demangle(context);
                }
                else
                {
                    context.Writer.Append("{vtt(");
                    Type.Demangle(context);
                    context.Writer.Append(");");
                }
            }
        }

        internal class TypeInfo : IParsingResult
        {
            public TypeInfo(IParsingResult type)
            {
                Type = type;
            }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("typeinfo for ");
                Type.Demangle(context);
            }
        }

        internal class TypeInfoName : IParsingResult
        {
            public TypeInfoName(IParsingResult type)
            {
                Type = type;
            }

            public IParsingResult Type { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("typeinfo name for ");
                Type.Demangle(context);
            }
        }

        internal class VirtualOverrideThunk : IParsingResult
        {
            public VirtualOverrideThunk(IParsingResult offset, IParsingResult encoding)
            {
                Offset = offset;
                Encoding = encoding;
            }

            public IParsingResult Encoding { get; private set; }

            public IParsingResult Offset { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("{virtual override thunk(");
                Offset.Demangle(context);
                context.Writer.Append(", ");
                Encoding.Demangle(context);
                context.Writer.Append(")}");
            }
        }

        internal class VirtualOverrideThunkCovariant : IParsingResult
        {
            public VirtualOverrideThunkCovariant(IParsingResult thisOffset, IParsingResult resultOffset, IParsingResult encoding)
            {
                ThisOffset = thisOffset;
                ResultOffset = resultOffset;
                Encoding = encoding;
            }

            public IParsingResult Encoding { get; private set; }

            public IParsingResult ResultOffset { get; private set; }

            public IParsingResult ThisOffset { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("{virtual override thunk(");
                ThisOffset.Demangle(context);
                context.Writer.Append(", ");
                ResultOffset.Demangle(context);
                context.Writer.Append(", ");
                Encoding.Demangle(context);
                context.Writer.Append(")}");
            }
        }

        internal class Guard : IParsingResult
        {
            public Guard(IParsingResult name)
            {
                Name = name;
            }

            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("guard variable for ");
                Name.Demangle(context);
            }
        }

        internal class GuardTemporary : IParsingResult
        {
            public GuardTemporary(IParsingResult name, int index)
            {
                Name = name;
                Index = index;
            }

            public int Index { get; private set; }

            public IParsingResult Name { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append("{static initialization guard temporary(");
                Name.Demangle(context);
                context.Writer.Append($", {Index})}}");
            }
        }
    }
}
