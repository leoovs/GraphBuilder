namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class BinaryExpressionSyntax : ExpressionSyntax
    {
        public ExpressionSyntax LeftOperand { get;  }
        public TokenSyntax Operation { get; }
        public ExpressionSyntax RightOperand { get; }

        public override IEnumerable<SyntaxNode> Children
        {
            get
            {
                yield return LeftOperand;
                yield return Operation;
                yield return RightOperand;
            }
        }

        public BinaryExpressionSyntax(ExpressionSyntax leftOperand,
            TokenSyntax operation, ExpressionSyntax rightOperand)
        {
            LeftOperand = leftOperand;
            Operation = operation;
            RightOperand = rightOperand;
        }
    }
}