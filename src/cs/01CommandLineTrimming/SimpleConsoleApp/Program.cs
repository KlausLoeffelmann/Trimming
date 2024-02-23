using AutoColumnListViewDemo.DataSources;

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

        //var typeDescriptor = TypeDescriptor.GetProvider(customer).GetTypeDescriptor(customer);
        //var properties = typeDescriptor.GetProperties();
        //foreach (PropertyInfo property in properties)
        //{
        //    Console.WriteLine($"{property.Name}: {property.GetValue(customer)}");
        //}

        var customerCompileTimeReflection = new CustomerCompileTimeReflectionResult();

        Console.WriteLine($"Hello, World, {customerCompileTimeReflection}!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
}
