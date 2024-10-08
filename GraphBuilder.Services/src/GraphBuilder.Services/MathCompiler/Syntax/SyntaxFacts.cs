namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public static class SyntaxFacts
    {
        public static int GetBinaryOperatorPrecedence(this TokenKind op)
        {
            switch (op)
            {
                case TokenKind.PlusOperator:
                case TokenKind.MinusOperator:
                    return 1;

                case TokenKind.MultiplyOperator:
                case TokenKind.DivideOperator:
                case TokenKind.ModuloOperator:
                    return 2;

                case TokenKind.PowerOperator:
                    return 4;
            }

            return 0;
        }

        public static int GetUnaryOperatorPrecedence(this TokenKind op)
        {
            switch (op)
            {
                case TokenKind.PlusOperator:
                case TokenKind.MinusOperator:
                    return 3;
            }

            return 0;
        }
    }
}