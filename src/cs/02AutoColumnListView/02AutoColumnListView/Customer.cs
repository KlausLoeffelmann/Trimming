using System.ComponentModel;

namespace AutoColumnListViewDemo;

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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
