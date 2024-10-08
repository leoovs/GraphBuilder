using System.Collections.Generic;

namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public abstract class SyntaxNode
    {
        public abstract IEnumerable<SyntaxNode> Children { get; }

        protected IEnumerable<SyntaxNode> NoChildren()
        {
            yield break;
        }
    }
}