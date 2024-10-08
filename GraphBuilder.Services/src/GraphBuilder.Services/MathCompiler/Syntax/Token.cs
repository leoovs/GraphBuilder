namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class Token
    {
        private TokenKind _kind;
        private string _text;
        private TextPosition _position = TextPosition.Begin;

        public string Text => _text;
        public TokenKind Kind => _kind;
        public TextPosition Position => _position;

        public Token(TokenKind kind, string text, TextPosition position)
        {
            _kind = kind;
            _text = text;
            _position = position;
        }

        public Token(TokenKind kind, TextPosition position)
        {
            _kind = kind;
            _position = position;
            _text = "";
        }

        public override string ToString()
        {
            return $"{_kind} Token (\"{_text}\")";
        }
    }
}
