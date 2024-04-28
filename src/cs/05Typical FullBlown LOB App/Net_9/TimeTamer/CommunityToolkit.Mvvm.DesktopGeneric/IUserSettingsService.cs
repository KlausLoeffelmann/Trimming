namespace DemoToolkit.Mvvm.DesktopGeneric;

public interface IUserSettingsService
{
    /// <summary>
    /// Gets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The key of the value.</param>
    /// <param name="defaultValue">The default value to return if the key is not found.</param>
    /// <returns>The value associated with the specified key, or the default value if the key is not found.</returns>
    public T Get<T>(string key, T defaultValue) where T : IParsable<T>;

    public T[] GetArray<T>(string key, T[] defaultValue) where T : IParsable<T>;

    /// <summary>
    /// Sets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The key of the value.</param>
    /// <param name="value">The value to set.</param>
    public void Set<T>(string key, T value) where T : IParsable<T>;

    public void SetArray<T>(string key, T[] value) where T : IParsable<T>;

    /// <summary>
    /// Removes the value associated with the specified key.
    /// </summary>
    /// <param name="key">The key of the value to remove.</param>
    public void Remove(string key);

    /// <summary>
    /// Determines whether the specified key exists.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>true if the key exists; otherwise, false.</returns>
    public bool Contains(string key);

    /// <summary>
    /// Clears all the key-value pairs.
    /// </summary>
    public void Clear();

    /// <summary>
    /// Saves the changes made to the user settings.
    /// </summary>
    public void Save();

    /// <summary>
    /// Loads the user settings.
    /// </summary>
    public void Load();
}
