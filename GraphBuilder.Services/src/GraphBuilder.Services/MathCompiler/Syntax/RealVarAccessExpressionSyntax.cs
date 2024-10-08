namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class RealVarAccessExpressionSyntax : ExpressionSyntax
    {
        public TokenSyntax Identifier { get; }

        public override IEnumerable<SyntaxNode> Children
        {
            get { yield return Identifier; }
        }

        public RealVarAccessExpressionSyntax(TokenSyntax identifier)
        {
            Identifier = identifier;
        }
    }
}