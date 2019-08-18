using System.Text;

namespace CxxDemangler
{
    internal class SimpleStringWriter
    {
        public StringBuilder StringBuilder { get; private set; } = new StringBuilder();

        public char Last
        {
            get
            {
                return StringBuilder.Length > 0 ? StringBuilder.ToString()[StringBuilder.Length - 1] : char.MinValue;
            }
        }

        public string Text
        {
            get
            {
                return StringBuilder.ToString();
            }
        }

        public void Append(string text)
        {
            StringBuilder.Append(text);
        }

        public void EnsureSpace()
        {
            if (Last != ' ')
            {
                Append(" ");
            }
        }
    }
}
