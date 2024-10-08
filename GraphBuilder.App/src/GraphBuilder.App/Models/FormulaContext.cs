using GraphBuilder.Services.MathCompiler;
using GraphBuilder.Services.MathCompiler.Syntax;

namespace GraphBuilder.App.Models
{
    class FormulaContext
    {
        private SimpleDiagnostics _contextErrors = new();
        private Formula? _boundFormula;

        private Dictionary<string, double> _parameters = new();
        private Dictionary<string, double> _constants = new();
        private Dictionary<string, Func<double, double>> _builtinFunctions
            = new();
        private string _argumentName = "x";

        public Formula BoundFormula => _boundFormula!;

        public Diagnostics ContextErrors => _contextErrors;
        public Color LineColor { get; set; } = Color.BlueViolet;
        public InterpolationMode InterpolationMode { get; set; } =
            InterpolationMode.LineInterpolation;

        public HashSet<string> ConstantNames => _constants.Keys.ToHashSet();
        public HashSet<string> BuiltinFunctionNames => _builtinFunctions.Keys.ToHashSet();
        public HashSet<string> ParameterNames => _parameters.Keys.ToHashSet(); 

        public FormulaContext()
        {
        }

        public FormulaContext InheritSetup(FormulaContext other)
        {
            _constants = new Dictionary<string, double>(other._constants);
            _builtinFunctions = new Dictionary<string, Func<double, double>>(
                other._builtinFunctions);
            _parameters = new Dictionary<string, double>(other._parameters);
            LineColor = other.LineColor;
            InterpolationMode = other.InterpolationMode;

            return this;
        }

        public FormulaContext DoDefaultSetup()
        {
            SetConstant("PI", Math.PI);
            SetConstant("E", Math.E);

            SetFunction("sin", Math.Sin);
            SetFunction("cos", Math.Cos);
            SetFunction("tg", Math.Tan);
            SetFunction("ctg", (x) => 1.0 / Math.Tan(x));
            SetFunction("exp", Math.Exp);
            SetFunction("ln", Math.Log);
            SetFunction("lg", Math.Log10);
            SetFunction("sqrt", Math.Sqrt);
            SetFunction("abs", Math.Abs);

            return this;
        }

        public void Update(Formula formula)
        {
            _contextErrors.Clear();
            _boundFormula = formula;
            _contextErrors.UnionWith(_boundFormula.SyntaxErrors);
            if (!_contextErrors.Any())
            {
                Update();
            }
        }

        public void SetParameter(string name, double value)
        {
            if (!IsParameterName(name))
            {
                throw new Exception("Invalid parameter name");
            }

            _parameters[name] = value;
        }

        public double GetParameter(string name)
        {
            if (!IsParameterName(name))
            {
                throw new Exception("Invalid parameter name");
            }

            return _parameters[name];
        }

        public void SetConstant(string name, double value)
        {
            if (IsParameterName(name))
            {
                throw new Exception("Constant name cannot be a parameter name");
            }

            _constants[name] = value;
        }

        public double GetConstant(string name)
        {
            return _constants[name];
        }

        public void SetFunction(string name, Func<double, double> function)
        {
            _builtinFunctions[name] = function;
        }

        public Func<double, double> GetFunction(string name)
        {
            return _builtinFunctions[name];
        }

        private void Update()
        {
            var stack = new Stack<SyntaxNode>();
            stack.Push(_boundFormula!.Syntax.Root);
            var currentParameters = new HashSet<string>();
        
            while (stack.Any())
            {
                var node = stack.Pop();

                if (node is RealVarAccessExpressionSyntax rva)
                {
                    string name = rva.Identifier.Token.Text;
                    
                    if (IsParameterName(name))
                    {
                        currentParameters.Add(name);
                        continue;
                    }
                    else if (IsNameOfConstant(name))
                    {
                        continue;
                    }
                    else if (name == _argumentName)
                    {
                        continue;
                    }

                    currentParameters.Add(name);
                    _parameters[name] = default(double);
                }
                else if (node is CallExpressionSyntax call)
                {
                    string name = call.Identifier.Token.Text;
                    TextPosition pos = call.Identifier.Position;

                    if (!IsBuiltinFunctionName(name))
                    {
                        _contextErrors.Add($"Неизвестная функция '{name}'", pos);
                    }

                    int argCount = call.Arguments.ToList().Count;
                    if (argCount != 1)
                    {
                        _contextErrors.Add($"Неверное количество аргументов ({argCount}), должен быть 1 аргумент",
                            pos);
                    }
                }

                foreach (var child in node.Children)
                {
                    stack.Push(child);
                }
            }
            string[] names = ParameterNames.ToArray();

            foreach (string paramName in names)
            {
                if (!currentParameters.Contains(paramName))
                {
                    _parameters.Remove(paramName);
                }
            }
        }

        public bool IsNameOfConstant(string name)
        {
            return _constants.ContainsKey(name);
        }

        public bool IsParameterName(string name)
        {
            return _parameters.ContainsKey(name);
        }

        public bool IsBuiltinFunctionName(string name)
        {
            return _builtinFunctions.ContainsKey(name);
        }

        public bool IsArgumentName(string name)
        {
            return name == _argumentName;
        }
    }
}