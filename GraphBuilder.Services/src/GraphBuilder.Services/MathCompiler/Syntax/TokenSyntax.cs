namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class TokenSyntax : SyntaxNode
    {
        public override IEnumerable<SyntaxNode> Children => NoChildren();
        public Token Token { get; }
        public TokenKind Kind => Token.Kind;
        public TextPosition Position => Token.Position;

        public TokenSyntax(Token token)
        {
            Token = token;
        }
    }
}