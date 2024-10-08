namespace GraphBuilder.App.Models
{
    class FormulaRegistry
    {
        private List<FormulaContext> _contexts = new();
        private List<bool> _enabled = new();

        public int Size => _contexts.Count;

        public FormulaContext GetContext(int id)
        {
            return _contexts[id];
        }

        public void AddContext(FormulaContext context)
        {
            _contexts.Add(context);
            _enabled.Add(true);
        }

        public void RemoveContext(int id)
        {
            _contexts.RemoveAt(id);
            _enabled.RemoveAt(id);
        }

        public void SetContext(int id, FormulaContext context)
        {
            _contexts[id] = context;
        }

        public void Enable(int id, bool enabled = true)
        {
            if (!Exists(id))
            {
                throw new Exception("Formula does not exist");
            }

            _enabled[id] = enabled;
        }

        public bool IsEnabled(int id)
        {
            if (!Exists(id))
            {
                throw new Exception("Formula does not exist");
            }

            return _enabled[id];
        }

        public bool Exists(int id)
        {
            return 0 <= id && id < _contexts.Count;
        }
    }
}