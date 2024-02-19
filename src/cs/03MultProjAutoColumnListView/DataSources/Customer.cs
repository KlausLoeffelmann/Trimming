using CommonLib.Attributes;
using DataSources.Resources;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AutoColumnListViewDemo.DataSources;

public class Customer : INotifyPropertyChanged
{
    private Guid _idCustomer;
    private int _customerNumber;
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _addressLine1;
    private string? _addressLine2;
    private string? _city;
    private string? _state;
    private string? _postalCode;

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

    [SRDisplayName(nameof(SR.Customer_DisplayName_IDCustomerName), typeof(SR))]
    public Guid IdCustomer
    {
        get => _idCustomer;
        set
        {
            if (_idCustomer != value)
            {
                _idCustomer = value;
                OnPropertyChanged(nameof(IdCustomer));
            }
        }
    }

    [SRDisplayName(nameof(SR.Customer_DisplayName_CustomerNumber), typeof(SR))]
    public int CustomerNumber
    {
        get => _customerNumber;
        set
        {
            if (_customerNumber != value)
            {
                _customerNumber = value;
                OnPropertyChanged(nameof(CustomerNumber));
            }
        }
    }

    [SRDisplayName(nameof(SR.Customer_DisplayName_FirstName), typeof(SR))]
    public string? FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName != value)
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
    }

    private static string GenerateRandomFirstName()
    {
        string[] firstNames = ["John", "Emma", "Michael", "Olivia", "William", "Ava", "James", "Sophia", "Benjamin", "Isabella"];
        Random random = new();
        return firstNames[random.Next(firstNames.Length)];
    }

    [SRDisplayName(nameof(SR.Customer_DisplayName_LastName), typeof(SR))]
    public string? LastName
    {
        get => _lastName;
        set
        {
            if (_lastName != value)
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
    }

    private static string GenerateRandomLastName()
    {
        string[] lastNames = ["Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor"];
        Random random = new();
        return lastNames[random.Next(lastNames.Length)];
    }

    [SRDisplayName(nameof(SR.Customer_DisplayName_Email), typeof(SR))]
    public string? Email
    {
        get => _email;
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
    }

    private static string GenerateRandomEmail()
    {
        string[] domains = ["gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "aol.com"];
        Random random = new();
        string firstName = GenerateRandomFirstName();
        string lastName = GenerateRandomLastName();
        return $"{firstName.ToLower()}.{lastName.ToLower()}@{domains[random.Next(domains.Length)]}";
    }

    [SRDisplayName(nameof(SR.Customer_DisplayName_AddressLine1), typeof(SR))]
    public string? AddressLine1
    {
        get => _addressLine1;
        set
        {
            if (_addressLine1 != value)
            {
                _addressLine1 = value;
                OnPropertyChanged(nameof(AddressLine1));
            }
        }
    }

    [SRDisplayName(nameof(SR.Customer_DisplayName_AddressLine2), typeof(SR))]
    public string? AddressLine2
    {
        get => _addressLine2;
        set
        {
            if (_addressLine2 != value)
            {
                _addressLine2 = value;
                OnPropertyChanged(nameof(AddressLine2));
            }
        }
    }

    private static string GenerateRandomAddressLine()
    {
        string[] addressLines = ["123 Main St", "456 Elm St", "789 Oak St", "321 Pine St", "654 Maple St"];
        Random random = new();
        return addressLines[random.Next(addressLines.Length)];
    }

    [SRDisplayName(nameof(SR.Customer_DisplayName_City), typeof(SR))]
    public string? City
    {
        get => _city;
        set
        {
            if (_city != value)
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
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

    [SRDisplayName(nameof(SR.Customer_DisplayName_PostalCode), typeof(SR))]
    public string? PostalCode
    {
        get => _postalCode;
        set
        {
            if (_postalCode != value)
            {
                _postalCode = value;
                OnPropertyChanged(nameof(PostalCode));
            }
        }
    }

    private static string GenerateRandomPostalCode()
    {
        Random random = new();
        return random.Next(10000, 99999).ToString();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
