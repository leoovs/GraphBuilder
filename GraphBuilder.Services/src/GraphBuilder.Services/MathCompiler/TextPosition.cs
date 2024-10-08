namespace GraphBuilder.Services.MathCompiler
{
    public struct TextPosition
    {
        public static readonly TextPosition Begin = new TextPosition(0, 0);

        public int CharIndex { get; set; }
        public int LineIndex { get; set; }
        public int TokenIndex => _tokenIndex;

        private int _tokenIndex = 0;

        public TextPosition(int charIndex, int lineIndex)
        {
            CharIndex = charIndex;
            LineIndex = lineIndex;
        }

        public void Advance(int upperBorder)
        {
            if (CharIndex < upperBorder)
            {
                _tokenIndex++;
                CharIndex++;
            }
        }

        public void JumpOff()
        {
            _tokenIndex = 0;
            LineIndex++;
        }

        public override string ToString()
        {
            return $"{LineIndex + 1}:{TokenIndex + 1}";
        }
    }
}