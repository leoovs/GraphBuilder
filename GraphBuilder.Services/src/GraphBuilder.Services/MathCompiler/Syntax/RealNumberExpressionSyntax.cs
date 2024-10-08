using System.Globalization;

namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public sealed class RealNumberExpressionSyntax : ExpressionSyntax
    {
        public TokenSyntax RealNumberToken { get; }
        public double PreEvaluationResult { get; }

        public override IEnumerable<SyntaxNode> Children
        {
            get { yield return RealNumberToken; }
        }

        public RealNumberExpressionSyntax(TokenSyntax realNumberToken)
        {
            RealNumberToken = realNumberToken;

            var culture = new CultureInfo("en-US");
            double.TryParse(RealNumberToken.Token.Text, culture,
                out double value);

            PreEvaluationResult = value;
        }
    }
}