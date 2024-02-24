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
                    // Get the type symbol of the generic argument of the class:
                    var typeSymbol = context.SemanticModel.GetSymbolInfo(classDeclarationSyntax.BaseList.Types.First().Type).Symbol as INamedTypeSymbol;

                    // Get the list of public properties of the generic argument of the class:
                    var properties = typeSymbol.GetMembers().Where(m => m.Kind == SymbolKind.Property && m.DeclaredAccessibility == Accessibility.Public);

                    // Get the list of Attributes of the generic argument of the class:
                    var attributes = typeSymbol.GetAttributes();

                    // Iterate through the properties, and get the type symbols of the attributes of each property.
                    // And then store them in a dictionary.
                    foreach (var property in properties)
                    {
                        var propertyAttributes = property.GetAttributes();
                        foreach (var attribute in propertyAttributes)
                        {
                            var attributeType = attribute.AttributeClass;
                            var attributeTypeSymbol = attributeType as INamedTypeSymbol;
                            var attributeTypeQualifiedName = attributeTypeSymbol.ToDisplayString(NullableFlowState.NotNull);
                        }
                    }
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
