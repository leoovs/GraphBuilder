namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class UnaryExpressionSyntax : ExpressionSyntax
    {
        public TokenSyntax Operation { get; }
        public ExpressionSyntax Operand { get; }

        public override IEnumerable<SyntaxNode> Children
        {
            get
            {
                yield return Operation;
                yield return Operand;
            }
        }

        public UnaryExpressionSyntax(TokenSyntax operation,
            ExpressionSyntax operand)
        {
            Operation = operation;
            Operand = operand;
        }
    }
}
