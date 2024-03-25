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

        TypeDescriptionProvider originalProvider = TypeDescriptor.GetProvider(typeof(object));
        var globalBindingProvider = new BindingTypeDescriptionProvider(originalProvider);
        TypeDescriptor.AddProvider(globalBindingProvider, typeof(object));

        var properties = TypeDescriptor.GetProperties(typeof(Customer));    
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(customer)}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
}
