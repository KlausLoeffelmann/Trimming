using Microsoft.CodeAnalysis;
using System;

namespace CompileTimeReflection;

[Generator]
public partial class CompileTimeReflectionGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new CompileTimeReflectionReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxReceiver is not CompileTimeReflectionReceiver syntaxReceiver)
        {
            throw new InvalidOperationException("Got the wrong syntax receiver type.");
        }
    }
}
