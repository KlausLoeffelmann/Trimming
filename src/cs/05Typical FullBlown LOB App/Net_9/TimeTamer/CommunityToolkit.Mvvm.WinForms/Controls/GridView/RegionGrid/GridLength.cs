namespace CommunityToolkit.Mvvm.WinForms.Controls;

/// <summary>
///  Provides a type that represents the length of elements within a grid.
/// </summary>
public struct GridLength
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GridLength"/> struct with the specified value.
    /// </summary>
    /// <param name="value">The value of the GridLength.</param>
    public GridLength(string value)
    {
        if (value == "*")
        {
            Value = 1;
            IsStar = true;
            IsAbsolute = false;
        }
        else if (value.EndsWith('*'))
        {
            Value = float.Parse(value[..^1]);
            IsStar = true;
            IsAbsolute = false;
        }
        else if (value.Equals("auto", StringComparison.InvariantCultureIgnoreCase))
        {
            Value = 0;
            IsStar = false;
            IsAbsolute = false;
        }
        else
        {
            Value = float.Parse(value);
            IsStar = false;
            IsAbsolute = true;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GridLength"/> struct with the specified value.
    /// </summary>
    /// <param name="value">The value of the GridLength.</param>
    public GridLength(float value)
    {
        Value = value;
        IsStar = false;
        IsAbsolute = true;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GridLength"/> struct with the specified value and properties.
    /// </summary>
    /// <param name="value">The value of the GridLength.</param>
    /// <param name="isStar">A value indicating whether the GridLength is a star length.</param>
    /// <param name="isAbsolute">A value indicating whether the GridLength is an absolute length.</param>
    public GridLength(float value, bool isStar, bool isAuto, bool isAbsolute)
    {
        Value = value;
        IsStar = isStar;
        IsAbsolute = isAbsolute;
    }

    /// <summary>
    /// Gets the value of the GridLength.
    /// </summary>
    public float Value { get; }

    /// <summary>
    /// Gets a value indicating whether the GridLength is a star length.
    /// </summary>
    public bool IsStar { get; }

    /// <summary>
    /// Gets a value indicating whether the GridLength is an absolute length.
    /// </summary>
    public bool IsAbsolute { get; }

    internal GridInfo? Parent { get; set; }
}
