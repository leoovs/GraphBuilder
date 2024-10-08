using GraphBuilder.Services.MathCompiler.Syntax;
using System.Globalization;

namespace GraphBuilder.App.Models
{
    class FormulaEvaluator
    {
        private FormulaContext _context;
        private SyntaxTree _syntax;
        private double _argument;

        public FormulaEvaluator(FormulaContext context, double argument)
        {
            _context = context;
            _syntax = context.BoundFormula.Syntax;
            _argument = argument;
        }

        public double Evaluate()
        {
            return EvaluateExpression(_syntax.Root.Definition);
        }

        private double EvaluateExpression(ExpressionSyntax expression)
        {
            if (expression is RealNumberExpressionSyntax rne)
            {
                return EvaluateRealNumberExpression(rne);
            }
            else if (expression is RealVarAccessExpressionSyntax rva)
            {
                return EvaluateRealVarExpression(rva);
            }
            else if (expression is UnaryExpressionSyntax unary)
            {
                return EvaluateUnaryExpression(unary);
            }
            else if (expression is BinaryExpressionSyntax binary)
            {
                return EvaluateBinaryExpression(binary);
            }
            else if (expression is CallExpressionSyntax call)
            {
                return EvaluateCallExpression(call);
            }

            throw new Exception("Unknown SyntaxNode");
        }

        private double EvaluateRealNumberExpression(RealNumberExpressionSyntax rne)
        {
            return rne.PreEvaluationResult;
        }

        private double EvaluateRealVarExpression(RealVarAccessExpressionSyntax rva)
        {
            var name = rva.Identifier.Token.Text;
            if (_context.IsParameterName(name))
            {
                return _context.GetParameter(name);
            }
            else if (_context.IsNameOfConstant(name))
            {
                return _context.GetConstant(name);
            }
            else if (_context.IsArgumentName(name))
            {
                return _argument;
            }

            return double.NaN;
        }

        public double EvaluateUnaryExpression(UnaryExpressionSyntax unary)
        {
            double res = EvaluateExpression(unary.Operand);
            return unary.Operation.Kind == TokenKind.PlusOperator ? res : -res;
        }

        public double EvaluateBinaryExpression(BinaryExpressionSyntax binary)
        {
            double left = EvaluateExpression(binary.LeftOperand);
            double right = EvaluateExpression(binary.RightOperand);

            switch (binary.Operation.Kind)
            {
                case TokenKind.PlusOperator:
                    return left + right;
                case TokenKind.MinusOperator:
                    return left - right;
                case TokenKind.MultiplyOperator:
                    return left * right;
                case TokenKind.DivideOperator:
                    return left / right;
                case TokenKind.ModuloOperator:
                    return left % right;
                case TokenKind.PowerOperator:
                    return Math.Pow(left, right);
                default:
                    return double.NaN;
            }
        }

        private double EvaluateCallExpression(CallExpressionSyntax call)
        {
            string name = call.Identifier.Token.Text;
            double argument = EvaluateExpression(call.Arguments.First());

            if (_context.IsBuiltinFunctionName(name))
            {
                return _context.GetFunction(name)(argument);
            }

            return double.NaN;
        }
    }
}