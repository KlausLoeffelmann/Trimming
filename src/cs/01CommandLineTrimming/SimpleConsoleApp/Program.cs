using AutoColumnListViewDemo.DataSources;
using System.ComponentModel;
using System.Reflection;

namespace SimpleConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Customer customer = new()
        {
            IdCustomer = Guid.NewGuid(),
            CustomerNumber = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john@doe.de"
        };

        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            // Check if the assembly has a location. Some assemblies might be loaded in memory and won't have a physical location.
            if (!string.IsNullOrEmpty(assembly.Location))
            {
                Console.WriteLine($"Assembly: {assembly.GetName().Name}");
                Console.WriteLine($"Path: {assembly.Location}\n");
            }
            else
            {
                // Handle assemblies without a location, if necessary.
                Console.WriteLine($"Assembly: {assembly.GetName().Name} is loaded in memory.");
            }
        }

        var typeDescriptor = TypeDescriptor.GetProvider(customer).GetTypeDescriptor(customer);
        var properties = typeDescriptor.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(customer)}");
        }

        var customerCompileTimeReflection = new CustomerCompileTimeReflectionResult();

        Console.WriteLine($"Hello, World, {customerCompileTimeReflection}!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
}
