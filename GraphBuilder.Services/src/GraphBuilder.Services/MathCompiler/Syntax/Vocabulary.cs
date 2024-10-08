using System.Collections.Generic;

namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class Vocabulary
    {
        private HashSet<char> _isOperatorHash = new HashSet<char>();
        private Dictionary<char, TokenKind> _tokenKindMap =
            new Dictionary<char, TokenKind>();

        public Vocabulary()
        {
            SetupIsOperatorHash();
            SetupTokenKindMap();
        }

        public bool IsNewLine(char c)
        {
            return c == '\n';
        }

        public bool IsSpace(char c)
        {
            return char.IsWhiteSpace(c) && c != '\n';
        }

        public bool IsOperator(char c)
        {
            return _isOperatorHash.Contains(c);
        }

        public bool IsRealNumberStart(char c)
        {
            return char.IsDigit(c);
        }

        public bool IsRealNumber(char c)
        {
            return IsRealNumberStart(c) || c == '.';
        }

        public bool IsIdentifierStart(char c)
        {
            return char.IsLetter(c) || '_' == c;
        }

        public bool IsIdentifierPart(char c)
        {
            return IsIdentifierStart(c) || char.IsLetterOrDigit(c);
        }

        public TokenKind ToTokenKind(char c)
        {
            return _tokenKindMap.ContainsKey(c)
                ? _tokenKindMap[c]
                : TokenKind.Invalid;
        }

        private void SetupIsOperatorHash()
        {
            _isOperatorHash.UnionWith(
                new char[]
                {
                    '=',
                    '+',
                    '-',
                    '*',
                    '/',
                    '%',
                    '^',
                    ',',
                    '(',
                    ')',
                    '[',
                    ']'
                }
            );
        }

        private void SetupTokenKindMap()
        {
            _tokenKindMap['='] = TokenKind.EqualsOperator;
            _tokenKindMap['+'] = TokenKind.PlusOperator;
            _tokenKindMap['-'] = TokenKind.MinusOperator;
            _tokenKindMap['*'] = TokenKind.MultiplyOperator;
            _tokenKindMap['/'] = TokenKind.DivideOperator;
            _tokenKindMap['%'] = TokenKind.ModuloOperator;
            _tokenKindMap['^'] = TokenKind.PowerOperator;
            _tokenKindMap[','] = TokenKind.CommaOperator;
            _tokenKindMap['('] = TokenKind.OpenParenthesis;
            _tokenKindMap[')'] = TokenKind.CloseParenthesis;
            _tokenKindMap['['] = TokenKind.OpenBracket;
            _tokenKindMap[']'] = TokenKind.CloseBracket;
        }
    }
}