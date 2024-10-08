namespace GraphBuilder.Services.MathCompiler
{
    public abstract class Diagnostics
    {
        public abstract IEnumerable<string> Messages { get; }
        public abstract IEnumerable<TextPosition> Occurrences { get; }

        public abstract void UnionWith(Diagnostics other);
        public abstract bool Any();

        public override abstract string ToString();
    }
}