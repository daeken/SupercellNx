using System.Collections.Generic;

namespace CxxDemangler
{
    internal class SubstitutionTable
    {
        internal List<IParsingResult> Substitutions { get; private set; } = new List<IParsingResult>();

        public int Size
        {
            get
            {
                return Substitutions.Count;
            }
        }

        public void Add(IParsingResult substitution)
        {
            Substitutions.Add(substitution);
        }

        public bool Contains(int number)
        {
            return number < Substitutions.Count;
        }

        public void Rewind(int oldSize)
        {
            if (Substitutions.Count > oldSize)
            {
                Substitutions.RemoveRange(oldSize, Substitutions.Count - oldSize);
            }
        }
    }
}
