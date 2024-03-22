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

        var typeDescriptor = TypeDescriptor.GetReflectionType(typeof(Customer));
        var properties = typeDescriptor.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(customer)}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
}
