namespace GraphBuilder.Services.MathCompiler.Syntax
{
   public sealed class FunctionDefinitionSyntax : SyntaxNode
   {
        public TokenSyntax DependentVar { get; }
        public TokenSyntax EqualsSign { get; }
        public ExpressionSyntax Definition { get; }
   
        public override IEnumerable<SyntaxNode> Children
        {
            get
            {
                yield return DependentVar;
                yield return EqualsSign;
                yield return Definition;
            }
        }

        public FunctionDefinitionSyntax(TokenSyntax dependentVar,
            TokenSyntax equalsSign, ExpressionSyntax definition)
        {
            DependentVar = dependentVar;
            EqualsSign = equalsSign;
            Definition = definition;
        }
   } 
}