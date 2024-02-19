using AutoColumnListViewDemo.Controls;
using AutoColumnListViewDemo.Resources;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AutoColumnListViewDemo.DataSources
{
    public class Products : INotifyPropertyChanged
    {
        private Guid _idProduct;
        private string? _productName;
        private decimal _price;
        private int _quantity;

        public static async Task GenerateSampleRecordsAsync(ObservableCollection<Products> products, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Products product = new()
                {
                    IdProduct = Guid.NewGuid(),
                    ProductName = GenerateRandomProductName(),
                    Price = GenerateRandomPrice(),
                    Quantity = GenerateRandomQuantity()
                };

                products.Add(product);
                await Task.Delay(100); // Delay to simulate asynchronous operation
            }
        }

        [SRDisplayName(nameof(SR.Products_DisplayName_IdProduct), typeof(SR))]
        public Guid IdProduct
        {
            get => _idProduct;
            set
            {
                if (_idProduct != value)
                {
                    _idProduct = value;
                    OnPropertyChanged(nameof(IdProduct));
                }
            }
        }

        [SRDisplayName(nameof(SR.Products_DisplayName_ProductName), typeof(SR))]
        public string? ProductName
        {
            get => _productName;
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }
        }

        private static string GenerateRandomProductName()
        {
            string[] productNames = ["iPhone", "Samsung Galaxy", "MacBook Pro", "Dell XPS", "PlayStation 5", "Xbox Series X", "Nintendo Switch", "AirPods Pro", "Apple Watch", "Fitbit"];
            Random random = new();
            return productNames[random.Next(productNames.Length)];
        }

        [SRDisplayName(nameof(SR.Products_DisplayName_Price), typeof(SR))]
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        private static decimal GenerateRandomPrice()
        {
            Random random = new();
            return Math.Round(random.NextDouble() * 1000, 2);
        }

        [SRDisplayName(nameof(SR.Products_DisplayName_Quantity), typeof(SR))]
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        private static int GenerateRandomQuantity()
        {
            Random random = new();
            return random.Next(1, 100);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
