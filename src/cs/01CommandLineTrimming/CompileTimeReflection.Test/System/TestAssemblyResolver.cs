using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.Reflection;

namespace CompileTimeReflection.Test.System;

internal static class TestAssemblyResolver
{
    private static readonly string[] s_requiredAssemblies =
        [
            "System.Private.CoreLib",
            "System.Runtime",
            "System.ObjectModel",
            "System.ComponentModel.TypeConverter",
            "System.Console"
        ];

    public static Compilation CreateCompilation(string source, PortableExecutableReference[] additionalProjectReferences)
    {
        // Get the reference to the core library
        var privateCoreLib = MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location);

        // Extract just the base-path of the assembly location, so we have a hint-path for the System.Runtime reference.
        var basePath = Path.GetDirectoryName(privateCoreLib.Display) 
            ?? throw new InvalidOperationException("Could not determine base path of the core library.");

        // Create the compilation that will be used to generate the source.
        var references = s_requiredAssemblies.Select(assemblyName =>
        {
            var path = Path.Combine(basePath, assemblyName + ".dll");
            return MetadataReference.CreateFromFile(path);
        }).ToList();

        // Add the passed references.
        references.AddRange(additionalProjectReferences);

        // Create the compilation.
        var compilation = CSharpCompilation.Create(
            assemblyName: "compilation",
            syntaxTrees:
                [
                    CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.Preview))
                ],
            references: references,
            options: new CSharpCompilationOptions(OutputKind.ConsoleApplication));

        return compilation;
    }

    public static GeneratorDriver CreateDriver(Compilation compilation, params ISourceGenerator[] generators) => CSharpGeneratorDriver.Create(
        generators: ImmutableArray.Create(generators),
        additionalTexts: ImmutableArray<AdditionalText>.Empty,
        parseOptions: (CSharpParseOptions)compilation.SyntaxTrees.First().Options,
        optionsProvider: null
    );

    public static Compilation RunGenerators(Compilation compilation, out ImmutableArray<Diagnostic> diagnostics, params ISourceGenerator[] generators)
    {
        CreateDriver(compilation, generators).RunGeneratorsAndUpdateCompilation(compilation, out var updatedCompilation, out diagnostics);
        return updatedCompilation;
    }
}
