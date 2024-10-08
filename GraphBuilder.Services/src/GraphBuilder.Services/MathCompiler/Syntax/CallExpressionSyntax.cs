namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class CallExpressionSyntax : ExpressionSyntax
    {
        private List<ExpressionSyntax> _arguments;

        public TokenSyntax Identifier { get; }
        public IEnumerable<ExpressionSyntax> Arguments => _arguments;

        public override IEnumerable<SyntaxNode> Children
        {
            get
            {
                yield return Identifier;
                foreach (ExpressionSyntax argument in Arguments)
                {
                    yield return argument;
                }
            }
        }

        public CallExpressionSyntax(TokenSyntax identifier,
            List<ExpressionSyntax> arguments)
        {
            Identifier = identifier;
            _arguments = arguments;
        }
    }
}