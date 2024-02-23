using CompileTimeReflection;
using CompileTimeReflection.Test.TestData;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using static CompileTimeReflection.Test.System.TestAssemblyResolver;

namespace PowerTools.UnitTests
{
    public class BasicCodeGenTest
    {
        [Fact]
        public void SimpleCodeGenTest()
        {
            string userSource =
                """
                //using CommonLib;
                //using CommonLib.Attributes;
                using CompileTimeReflection.Test.TestData;
                using System;
                
                //public partial class AotReflectionTypeDescriptor : AotReflectionTypeDescriptor<Contact>
                //{

                //}

                internal class Program
                {
                    static void Main(string[] args)
                    {
                        Contact contact = new()
                        {
                            IdContact = Guid.NewGuid(),
                            ContactNumber = 1234567890,
                            FirstName = "John",
                            LastName = "Doe",
                            DateOfBirth = new DateTime(1980, 1, 1)
                        };

                        Console.WriteLine("Press any key to exit...");
                        Console.ReadLine();
                    }
                }
                
                """;


            var additionalReferences = new[]
            {
                MetadataReference.CreateFromFile(typeof(Contact).GetTypeInfo().Assembly.Location)
            };
            
            Compilation comp = CreateCompilation(userSource, additionalReferences);

            var newComp = RunGenerators(comp, out var generatorDiagnostics, new AotReflectionGenerator());

            Assert.Empty(generatorDiagnostics);
            var diagnostic = newComp.GetDiagnostics();
            Assert.Empty(diagnostic);
        }
    }
}
