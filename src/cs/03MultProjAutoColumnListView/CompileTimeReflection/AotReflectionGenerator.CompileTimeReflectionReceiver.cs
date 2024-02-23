using CommonLib;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace CompileTimeReflection;

public partial class AotReflectionGenerator
{
    internal class CompileTimeReflectionReceiver : ISyntaxContextReceiver
    {
        private const string targetTypeQualifiedName = nameof(AotReflectionTypeDescriptor<object>);

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is ClassDeclarationSyntax classDeclarationSyntax)
            {
                if (classDeclarationSyntax.BaseList?.Types.Any(t => CheckTargetClass(context, t)) == true
                && classDeclarationSyntax.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)))
                {
                    // Test code for class derived from AotReflectionTypeDescriptor<T> and is partial
                    // ...
                }
            }

            // Test code for AotReflectionPropertyDescriptor<T>, which is the base class for a class which we need to extend.
            static bool CheckTargetClass(GeneratorSyntaxContext context, BaseTypeSyntax t)
            {
                // Get the symbol information for the GenericNameSyntax
                var typeSymbol = context.SemanticModel.GetSymbolInfo(t).Symbol as INamedTypeSymbol;

                // Ensure the typeSymbol is not null and is a generic type
                if (typeSymbol is not null && typeSymbol.IsGenericType)
                {
                    // Compare the original definition of the type symbol to the target type
                    var originalDefinition = typeSymbol.OriginalDefinition;
                    if (originalDefinition.ToDisplayString(NullableFlowState.NotNull) == targetTypeQualifiedName)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
