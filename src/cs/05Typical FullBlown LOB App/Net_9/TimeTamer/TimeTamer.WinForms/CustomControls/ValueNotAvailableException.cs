
namespace TaskTamer9.WinForms.CustomControls
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