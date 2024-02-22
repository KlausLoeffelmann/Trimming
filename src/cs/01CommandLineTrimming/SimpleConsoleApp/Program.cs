using AutoColumnListViewDemo.DataSources;
using CommonLib;
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

        //var typeDescriptor = TypeDescriptor.GetProvider(customer).GetTypeDescriptor(customer);
        //var properties = typeDescriptor.GetProperties();
        //foreach (PropertyInfo property in properties)
        //{
        //    Console.WriteLine($"{property.Name}: {property.GetValue(customer)}");
        //}

        var customerCompileTimeReflection = new CustomerCompileTimeReflection();

        Console.WriteLine($"Hello, World, {customerCompileTimeReflection}!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
}

internal class CustomerCompileTimeReflection : CompileTimeReflectionTypeDescriptor<Customer>
{
    protected override Attribute[] GetAttributes()
    {
        throw new NotImplementedException();
    }

    protected override string GetClassName()
    {
        throw new NotImplementedException();
    }

    protected override string GetComponentName()
    {
        throw new NotImplementedException();
    }

    protected override TypeConverter GetConverter()
    {
        throw new NotImplementedException();
    }

    protected override EventDescriptor GetDefaultEvent()
    {
        throw new NotImplementedException();
    }

    protected override PropertyDescriptor GetDefaultProperty()
    {
        throw new NotImplementedException();
    }

    protected override object GetEditor(Type editorBaseType)
    {
        throw new NotImplementedException();
    }

    protected override EventDescriptor[] GetEvents()
    {
        throw new NotImplementedException();
    }

    protected override EventDescriptor[] GetEvents(Attribute[]? attributes)
    {
        throw new NotImplementedException();
    }

    protected override PropertyDescriptor[] GetProperties()
    {
        throw new NotImplementedException();
    }

    protected override PropertyDescriptor[] GetProperties(Attribute[]? attributes)
    {
        throw new NotImplementedException();
    }

    protected override object? GetPropertyOwner(PropertyDescriptor? pd)
    {
        throw new NotImplementedException();
    }
}
