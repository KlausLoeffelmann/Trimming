using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace CompileTimeReflection;

public partial class AotReflectionGenerator
{
    internal class CompileTimeReflectionReceiver : ISyntaxReceiver
    {
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax)
            {
                if (classDeclarationSyntax.BaseList?.Types.Any(t => t.Type.ToString() == "AotReflectionTypeDescriptor<T>") == true &&
                    classDeclarationSyntax.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)))
                {
                    // Test code for class derived from AotReflectionTypeDescriptor<T> and is partial
                    // ...
                }
            }
        }
    }
}
