namespace GraphBuilder.Services.MathCompiler.Syntax
{
    public enum TokenKind
    {
        // Literals
        RealNumber,

        // Operators
        EqualsOperator,
        PlusOperator,
        MinusOperator,
        MultiplyOperator,
        DivideOperator,
        PowerOperator,
        CommaOperator,
        ModuloOperator,

        // Brackets
        OpenParenthesis,
        CloseParenthesis,
        OpenBracket,
        CloseBracket,

        // Special tokens
        Identifier,
        NewLine,
        Invalid,
        Missing,
        EndOfStream
    }
}