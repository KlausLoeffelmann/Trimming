using CommonLib.Attributes;
using DataSources.Resources;
using System.Collections.ObjectModel;

namespace AutoColumnListViewDemo.DataSources;

public partial class Customer
{
    public static async Task GenerateSampleRecordsAsync(ObservableCollection<Customer> customers, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Customer customer = new()
            {
                IdCustomer = Guid.NewGuid(),
                CustomerNumber = i + 1,
                FirstName = GenerateRandomFirstName(),
                LastName = GenerateRandomLastName(),
                Email = GenerateRandomEmail(),
                AddressLine1 = GenerateRandomAddressLine(),
                AddressLine2 = GenerateRandomAddressLine(),
                City = GenerateRandomCity(),
                State = GenerateRandomState(),
                PostalCode = GenerateRandomPostalCode()
            };

            customers.Add(customer);
            await Task.Delay(100); // Delay to simulate asynchronous operation
        }
    }

    private static string GenerateRandomFirstName()
    {
        string[] firstNames = ["John", "Emma", "Michael", "Olivia", "William", "Ava", "James", "Sophia", "Benjamin", "Isabella"];
        Random random = new();
        return firstNames[random.Next(firstNames.Length)];
    }

    private static string GenerateRandomLastName()
    {
        string[] lastNames = ["Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor"];
        Random random = new();
        return lastNames[random.Next(lastNames.Length)];
    }

    private static string GenerateRandomEmail()
    {
        string[] domains = ["gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "aol.com"];
        Random random = new();
        string firstName = GenerateRandomFirstName();
        string lastName = GenerateRandomLastName();
        return $"{firstName.ToLower()}.{lastName.ToLower()}@{domains[random.Next(domains.Length)]}";
    }

    private static string GenerateRandomAddressLine()
    {
        string[] addressLines = ["123 Main St", "456 Elm St", "789 Oak St", "321 Pine St", "654 Maple St"];
        Random random = new();
        return addressLines[random.Next(addressLines.Length)];
    }

    private static string GenerateRandomCity()
    {
        string[] cities = ["New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose"];
        Random random = new();
        return cities[random.Next(cities.Length)];
    }

    [SRDisplayName(nameof(SR.Customer_DisplayName_State), typeof(SR))]
    public string? State
    {
        get => _state;
        set
        {
            if (_state != value)
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }
    }

    private static string GenerateRandomState()
    {
        string[] states = ["California", "Texas", "Florida", "New York", "Pennsylvania", "Illinois", "Ohio", "Georgia", "North Carolina", "Michigan"];
        Random random = new();
        return states[random.Next(states.Length)];
    }

    private static string GenerateRandomPostalCode()
    {
        Random random = new();
        return random.Next(10000, 99999).ToString();
    }
}
