using System.Text;

namespace GraphBuilder.Services.MathCompiler
{
    public class SimpleDiagnostics : Diagnostics
    {
        private List<string> _messages = new List<string>();
        private List<TextPosition> _occurrences = new List<TextPosition>();

        public override IEnumerable<string> Messages => _messages; 
        public override List<TextPosition> Occurrences => _occurrences;

        public override void UnionWith(Diagnostics other)
        {
            if (other.Any())
            {
                _messages = _messages.Concat(other.Messages).ToList();
                _occurrences = _occurrences.Concat(other.Occurrences).ToList();
            }
        }

        public override bool Any()
        {
            return _messages.Any();
        }

        public void Clear()
        {
            _messages.Clear();
            _occurrences.Clear();
        }

        public void Add(string message, TextPosition occurrence)
        {
            _messages.Add(message);
            _occurrences.Add(occurrence);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            if (_messages.Count != _occurrences.Count)
            {
                throw new Exception("Messages and occurrences mismatch");
            }

            for (int i = 0; i < _messages.Count; i++)
            {
                string msg = _messages[i];
                TextPosition occurrence = _occurrences[i];

                builder
                    .Append(msg)
                    .Append(" (at ").Append(occurrence.ToString()).Append(")")
                    .AppendLine();
            }

            return builder.ToString();
        }
    }
}