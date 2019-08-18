namespace CxxDemangler
{
    internal class SimpleStringParser
    {
        public SimpleStringParser(string input)
        {
            Position = 0;
            Input = input;
        }

        public string Input { get; private set; }

        public int Position { get; set; }

        public char Peek
        {
            get
            {
                return Position >= Input.Length ? char.MaxValue : Input[Position];
            }
        }

        public bool IsEnd
        {
            get
            {
                return Position >= Input.Length;
            }
        }

        public bool VerifyString(string s)
        {
            if (Position + s.Length > Input.Length)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (Input[Position + i] != s[i])
                {
                    return false;
                }
            }

            Position += s.Length;
            return true;
        }

        public int? ParseNumber()
        {
            int number;

            if (!ParseNumber(out number))
            {
                return null;
            }
            return number;
        }

        public bool ParseNumber(out int number)
        {
            int start = Position;
            bool negative = false;

            if (Peek == 'n')
            {
                number = -1;
                Position++;
                negative = true;
            }

            if (!char.IsDigit(Peek))
            {
                Position = start;
                number = -1;
                return false;
            }

            int numberStart = Position;

            while (!IsEnd && char.IsDigit(Peek))
            {
                Position++;
            }

            int numberEnd = Position;

            if (!int.TryParse(Input.Substring(numberStart, numberEnd - numberStart), out number))
            {
                Position = start;
                return false;
            }
            if (negative)
            {
                number = -number;
            }

            return true;
        }

        public bool ParseNumberBase36(out int number)
        {
            if (!char.IsDigit(Peek) && !(Peek >= 'A' && Peek <= 'Z'))
            {
                number = 0;
                return false;
            }

            int numberStart = Position;

            number = 0;
            while (!IsEnd && (char.IsDigit(Peek) || (Peek >= 'A' && Peek <= 'Z')))
            {
                number *= 36;
                if (char.IsDigit(Peek))
                {
                    number += Peek - '0';
                }
                else
                {
                    number += Peek - 'A' + 10;
                }
                Position++;
            }
            return true;
        }

        public string ParseUntil(char endChar)
        {
            int startIndex = Position;

            while (!IsEnd && Peek != endChar)
            {
                Position++;
            }

            int endIndex = Position;

            return Input.Substring(startIndex, endIndex - startIndex);
        }
    }
}
