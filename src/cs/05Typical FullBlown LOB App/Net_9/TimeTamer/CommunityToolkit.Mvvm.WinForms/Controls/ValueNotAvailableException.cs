namespace DemoToolkit.Mvvm.WinForms.Controls;

    [Serializable]
public class ValueNotAvailableException : Exception
{
    public ValueNotAvailableException() { }

    public ValueNotAvailableException(string? message)
        : base(message) { }

    public ValueNotAvailableException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
