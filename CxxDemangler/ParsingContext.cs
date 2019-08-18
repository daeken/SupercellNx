namespace CxxDemangler
{
    internal struct RewindState
    {
        public int Position { get; set; }

        public int SubstitutionTableSize { get; set; }
    }

    internal struct ParsingContext
    {
        public SimpleStringParser Parser { get; set; }

        public SubstitutionTable SubstitutionTable { get; set; }

        public RewindState RewindState
        {
            get
            {
                return new RewindState()
                {
                    Position = Parser.Position,
                    SubstitutionTableSize = SubstitutionTable.Size,
                };
            }
        }

        public void Rewind(RewindState rewind)
        {
            Parser.Position = rewind.Position;
            SubstitutionTable.Rewind(rewind.SubstitutionTableSize);
        }
    }
}
