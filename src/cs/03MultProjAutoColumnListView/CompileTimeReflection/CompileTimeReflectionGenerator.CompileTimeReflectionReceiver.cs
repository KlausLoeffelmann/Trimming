using Microsoft.CodeAnalysis;

namespace CompileTimeReflection;

public partial class CompileTimeReflectionGenerator
{
    internal class CompileTimeReflectionReceiver : ISyntaxReceiver
    {
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
        }
    }
}
