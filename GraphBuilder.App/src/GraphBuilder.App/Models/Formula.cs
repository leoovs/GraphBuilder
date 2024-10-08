using GraphBuilder.Services.MathCompiler;
using GraphBuilder.Services.MathCompiler.Syntax;

namespace GraphBuilder.App.Models
{
    class Formula
    {
        private string _definition;
        private SyntaxTree _syntax;
        private SimpleDiagnostics _syntaxErrors = new();

        public string Defintion => _definition;
        public SyntaxTree Syntax => _syntax;
        public Diagnostics SyntaxErrors => _syntaxErrors;

        public Formula(string definition)
        {
            UpdateDefinition(definition);
        }

        public void UpdateDefinition(string definition)
        {
            _definition = definition;

            var parser = new Parser(definition);
            _syntax = parser.Parse();
            _syntaxErrors.UnionWith(parser.Diagnostics);
        }
    }
}