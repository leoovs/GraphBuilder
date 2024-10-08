namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class SyntaxTree
    {
        private FunctionDefinitionSyntax _root;
        private TokenSyntax _endOfStream;

        public FunctionDefinitionSyntax Root => _root;

        public static SyntaxTree Build(string text)
        {
            return new Parser(text).Parse();
        }

        public SyntaxTree(FunctionDefinitionSyntax root, TokenSyntax endOfStream)
        {
            _root = root;
            _endOfStream = endOfStream;
        }
    }
}