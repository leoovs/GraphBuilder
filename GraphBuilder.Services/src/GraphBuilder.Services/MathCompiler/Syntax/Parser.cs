using System.Transactions;

namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class Parser
    {
        private TokenSyntax[] _tokens;
        private int _currentTokenIndex = 0;

        private SimpleDiagnostics _diagnostics = new SimpleDiagnostics();

        public Diagnostics Diagnostics => _diagnostics;

        private TokenSyntax Current => Peek(0);
        private TokenSyntax Next => Peek(1);

        public Parser(string text)
        {
            var lexer = new Lexer(text);
            var tokens = new List<TokenSyntax>();

            Token token;
            do
            {
                token = lexer.Lex();
                tokens.Add(new TokenSyntax(token));
            } while (token.Kind != TokenKind.EndOfStream);

            _diagnostics.UnionWith(lexer.Diagnostics);
            _tokens = tokens.ToArray();
        }

        public SyntaxTree Parse()
        {
            FunctionDefinitionSyntax root = ParseFunctionDefinition();
            TokenSyntax endOfStream = MatchToken(TokenKind.EndOfStream);

            return new SyntaxTree(root, endOfStream);
        }

        private FunctionDefinitionSyntax ParseFunctionDefinition()
        {
            TokenSyntax dependentVar = MatchToken(TokenKind.Identifier);
            TokenSyntax equalsSign = MatchToken(TokenKind.EqualsOperator);
            ExpressionSyntax definition = ParseExpression();

            return new FunctionDefinitionSyntax(dependentVar,
                equalsSign, definition);
        }

        private ExpressionSyntax ParseExpression(int parentPrecedence = 0)
        {
            ExpressionSyntax primary;

            int unaryPrecedence = Current.Kind.GetUnaryOperatorPrecedence();
            if (unaryPrecedence != 0 && unaryPrecedence >= parentPrecedence)
            {
                TokenSyntax operation = GetCurrentAndAdvance();
                ExpressionSyntax operand = ParseExpression(unaryPrecedence);

                primary = new UnaryExpressionSyntax(operation, operand);
            }
            else
            {
                primary = ParsePrimaryExpression();
            }

            while (true)
            {
                int precedence = Current.Kind.GetBinaryOperatorPrecedence();
                if (precedence == 0 || precedence <= parentPrecedence)
                {
                    break;
                }

                TokenSyntax operation = GetCurrentAndAdvance();
                ExpressionSyntax right = ParseExpression(precedence);

                primary = new BinaryExpressionSyntax(primary, operation, right);
            }

            return primary;
        }

        private ExpressionSyntax ParsePrimaryExpression()
        {
            if (Current.Kind == TokenKind.OpenParenthesis)
            {
                TokenSyntax openParenthesis
                    = MatchToken(TokenKind.OpenParenthesis);
                ExpressionSyntax expression = ParseExpression();
                TokenSyntax closeParenthesis =
                    MatchToken(TokenKind.CloseParenthesis);

                return expression;
            }

            if (Current.Kind == TokenKind.Identifier)
            {
                if (Next.Kind == TokenKind.OpenParenthesis)
                {
                    return ParseCallExpression();                    
                }
                TokenSyntax identifier = MatchToken(TokenKind.Identifier);
                return new RealVarAccessExpressionSyntax(identifier);
            }

            return new RealNumberExpressionSyntax(
                MatchToken(TokenKind.RealNumber));
        }

        private CallExpressionSyntax ParseCallExpression()
        {
            TokenSyntax identifier = MatchToken(TokenKind.Identifier);
            TokenSyntax openParen = MatchToken(TokenKind.OpenParenthesis);
            TokenSyntax closeParen;

            if (Current.Kind == TokenKind.CloseParenthesis)
            {
                 closeParen = MatchToken(TokenKind.CloseParenthesis);
                return new CallExpressionSyntax(identifier,
                    new List<ExpressionSyntax>());
            }

            List<ExpressionSyntax> arguments = new List<ExpressionSyntax>();
            while (true) 
            {
                ExpressionSyntax argument = ParseExpression();
                arguments.Add(argument);

                if (Current.Kind == TokenKind.CommaOperator)
                { 
                    TokenSyntax separator = MatchToken(TokenKind.CommaOperator);
                }
                else
                {
                    break;
                }
            }

            closeParen = MatchToken(TokenKind.CloseParenthesis);

            return new CallExpressionSyntax(identifier, arguments);
        }

        private TokenSyntax Peek(int offset)
        {
            int index = _currentTokenIndex + offset;
            if (index >= _tokens.Length)
            {
                return _tokens.Last();
            }
            return _tokens[index];
        }

        private TokenSyntax GetCurrentAndAdvance()
        {
            TokenSyntax current = Current;
            Advance();
            return current;
        }

        private TokenSyntax MatchToken(TokenKind kind)
        {
            if (Current.Kind == kind)
            {
                return GetCurrentAndAdvance();
            }

            _diagnostics.Add($"Неожиданная лексема <{Current.Kind}>, ожидается <{kind}>",
                Current.Position);

            return new TokenSyntax(new Token(kind, Current.Position));
        }

        private void Advance()
        {
            if (_currentTokenIndex < _tokens.Length)
            {
                _currentTokenIndex++;
            }
        }
    }
}