namespace CommunityToolkit.Mvvm.WinForms.Controls
{
    [Serializable]
    internal class ValueNotAvailableException : Exception
    {
        public ValueNotAvailableException()
        {
        }

        public ValueNotAvailableException(string? message) : base(message)
        {
        }

        public ValueNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}