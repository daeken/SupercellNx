namespace CxxDemangler.Parsers
{
    // <call-offset> ::= h <nv-offset> _
    //               ::= v <v-offset> _
    internal class CallOffset
    {
        public static IParsingResult Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (context.Parser.VerifyString("h"))
            {
                int offset;

                if (!context.Parser.ParseNumber(out offset) || !context.Parser.VerifyString("_"))
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new NonVirtual(offset);
            }
            else if (context.Parser.VerifyString("v"))
            {
                int offset, virtualOffset;

                if (!context.Parser.ParseNumber(out offset) || !context.Parser.VerifyString("_")
                    || !context.Parser.ParseNumber(out virtualOffset) || !context.Parser.VerifyString("_"))
                {
                    context.Rewind(rewind);
                    return null;
                }

                return new Virtual(offset, virtualOffset);
            }

            return null;
        }

        internal class NonVirtual : IParsingResult
        {
            public NonVirtual(int offset)
            {
                Offset = offset;
            }

            public int Offset { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append($"{{offset({Offset})}}");
            }
        }

        internal class Virtual : IParsingResult
        {
            public Virtual(int offset, int virtualOffset)
            {
                Offset = offset;
                VirtualOffset = virtualOffset;
            }

            public int Offset { get; private set; }

            public int VirtualOffset { get; private set; }

            public void Demangle(DemanglingContext context)
            {
                context.Writer.Append($"{{virtual offset({Offset}, {VirtualOffset})}}");
            }
        }
    }
}
