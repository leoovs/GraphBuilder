namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class Lexer
    {
        private string _text;
        private TextPosition _currentPosition = TextPosition.Begin;

        private Token _currentToken = new Token(TokenKind.EndOfStream,
            TextPosition.Begin);

        private Vocabulary _vocabulary = new Vocabulary();
        private SimpleDiagnostics _diagnostics = new SimpleDiagnostics();

        public string Text => _text;
        public Diagnostics Diagnostics => _diagnostics;

        private char Current => Pick(0);
        private char Next => Pick(1);

        public Lexer(string text)
        {
            _text = text;
        }

        public Token Lex()
        {
            if (_vocabulary.IsSpace(Current))
            {
                SkipSpace();
            }

            if (IsEndOfStream())
            {
                _currentToken = new Token(TokenKind.EndOfStream,
                    _currentPosition);
            }
            else if (_vocabulary.IsNewLine(Current))
            {
                _currentToken = new Token(TokenKind.NewLine, "\\n",
                    _currentPosition);
                Advance();
                _currentPosition.JumpOff();
            }
            else if (_vocabulary.IsRealNumberStart(Current))
            {
                ParseRealNumber();
            }
            else if (_vocabulary.IsOperator(Current))
            {
                ParseOperator();
            }
            else if (_vocabulary.IsIdentifierStart(Current))
            {
                ParseIdentifier();
            }
            else
            {
                _currentToken = new Token(TokenKind.Invalid,
                    Current.ToString(), _currentPosition);
                _diagnostics.Add(
                    $"Неожиданный символ '{Current}'",
                    _currentPosition);
                Advance();
            }

            return _currentToken;
        }

        private char Pick(int offset)
        {
            int index = _currentPosition.CharIndex + offset;
            if (index < 0 || index >= _text.Length)
            {
                return '\0';
            }

            return _text[index];
        }

        private void Advance()
        {
            _currentPosition.Advance(_text.Length);
        }

        private bool IsEndOfStream()
        {
            return Current == '\0';
        }

        private void SkipSpace()
        {
            while (_vocabulary.IsSpace(Current))
            {
                Advance();
            }
        }

        private void ParseRealNumber()
        {
            TextPosition start = _currentPosition;
            bool dotMet = false;
            string number = string.Empty;

            while (_vocabulary.IsRealNumber(Current))
            {
                if (Current == '.')
                {
                    if (!_vocabulary.IsRealNumber(Next))
                    {
                        _currentToken = new Token(TokenKind.Invalid,
                            number, _currentPosition);
                        _diagnostics.Add(
                            $"Вещественное число не может заканчиваться на '.'",
                            _currentPosition);
                        Advance();
                        return;
                    }

                    if (dotMet)
                    {
                        _currentToken = new Token(TokenKind.Invalid,
                            Current.ToString(), _currentPosition);
                        _diagnostics.Add(
                            "Ожидалась цифра, но встречена точка",
                            _currentPosition);
                        Advance();
                        return;
                    }
                    dotMet = true;
                }

                number += Current;
                Advance();
            }

            if (_vocabulary.IsIdentifierStart(Current))
            {
                _currentToken = new Token(TokenKind.Invalid, Current.ToString(),
                    _currentPosition);
                _diagnostics.Add(
                    "Неправильная вещественная константа", _currentPosition);
                return;
            }

            _currentToken = new Token(TokenKind.RealNumber, number, start);
        }

        private void ParseOperator()
        {
            string op = Current.ToString();
            TokenKind kind = _vocabulary.ToTokenKind(Current);

            _currentToken = new Token(kind, op, _currentPosition);

            Advance();
        }

        private void ParseIdentifier()
        {
            string identifier = Current.ToString();
            TextPosition start = _currentPosition;
            Advance();

            while (_vocabulary.IsIdentifierPart(Current))
            {
                identifier += Current.ToString();
                Advance();
            }

            _currentToken = new Token(TokenKind.Identifier, identifier, start);
        }
    }
}
