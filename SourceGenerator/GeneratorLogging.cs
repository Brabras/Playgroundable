using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGenerator;

[Generator]
public sealed class GeneratorLogging : IIncrementalGenerator
{
    private static readonly DiagnosticDescriptor UnhandledException =
        new("XX0002",
            "Unhandled exception occurred",
            "The generator caused an exception {0}: {1} {2}",
            "error",
            DiagnosticSeverity.Error,
            true);

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValueProvider<ImmutableArray<SyntaxToken>> pipeline =
            context.SyntaxProvider.CreateSyntaxProvider(                                                                 // A
                                                        (node, _) => node is ClassDeclarationSyntax,                     // B
                                                        (syntax, _) => ((ClassDeclarationSyntax)syntax.Node).Identifier) // C
                   .Collect();                                                                                           // D

        context.RegisterSourceOutput(pipeline, Build); // E
    }

    private void Build(
        SourceProductionContext context,
        ImmutableArray<SyntaxToken> source)
    {
        try
        {
            if (source.Any(x => x.ValueText.Contains("asd")))
            {
                throw new Exception("AAAAAAAAAAAAAAAAA");
            }

            var text = string.Join("\n", source.Select(identifier => identifier.ValueText));
            text = "/*\n" + text + "\n*/";
            context.AddSource("ClassNames", text);
        }
        catch (Exception ex)
        {
            ReportExceptionDiagnostic(context: context,
                                      exception: ex,
                                      diagnosticFactory: _ => Diagnostic.Create(UnhandledException,
                                                                                null,
                                                                                ex.GetType(),
                                                                                ex.Message,
                                                                                ex.StackTrace));
        }
    }

    private static void ReportExceptionDiagnostic(
        SourceProductionContext context,
        Exception exception,
        Func
            <Exception, Diagnostic> diagnosticFactory)
    {
        try
        {
            var diagnostic = diagnosticFactory(exception);
            context.ReportDiagnostic(diagnostic);
        }
        catch
        {
        }
    }
}