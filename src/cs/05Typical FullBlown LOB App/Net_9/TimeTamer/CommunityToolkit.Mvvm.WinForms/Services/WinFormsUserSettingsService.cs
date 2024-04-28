using DemoToolkit.Mvvm.DesktopGeneric;
using System.Reflection;
using System.Text.Json;

namespace DemoToolkit.Mvvm.WinForms.Services;

public class WinFormsUserSettingsService : IUserSettingsService
{
    private const string _settingsFileName = "UserSettings.json";
    private Dictionary<string, string> _settings = [];

    private FileInfo GetUserApplicationPath()
    {
        // Getting the path to the user's application data folder:
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        // Let's build the path to the application's folder within the user's application data folder
        // based on the main assembly name and the version.
        var assembly = Assembly.GetEntryAssembly();

        if (assembly is null)
        {
            throw new InvalidOperationException("The entry assembly is null.");
        }

        // Getting the main assembly's name:
        string assemblyName = assembly.GetName().Name!;

        // Getting the main assembly's version:
        string version = assembly.GetName().Version!.ToString();

        // Building the path to the application's folder within the user's application data folder:
        string appFolder = Path.Combine(appDataPath, assemblyName, version);

        // Creating the directory if it doesn't exist:
        Directory.CreateDirectory(appFolder);

        // return a FileInfo object representing the settings file:
        return new FileInfo(Path.Combine(appFolder, _settingsFileName));
    }

    public void Clear() => _settings.Clear();

    public bool Contains(string key) => _settings.ContainsKey(key);

    public T Get<T>(string key, T defaultValue) where T : IParsable<T>
    {
        // Check if the key exists in the settings dictionary:
        if (_settings.TryGetValue(key, out string? value))
        {
            // Has been written in JSon, so we need to parse it back to the original type:
            return JsonSerializer.Deserialize<T>(value!)!;
        }

        // Return the default value if the key doesn't exist or the parsing failed:
        return defaultValue;
    }

    public T[] GetArray<T>(string key, T[] defaultValue) where T : IParsable<T>
    {
        // Check if the key exists in the settings dictionary:
        if (_settings.TryGetValue(key, out string? value))
        {
            // Has been written in JSon, so we need to parse it back to the original type:
            return JsonSerializer.Deserialize<T[]>(value!)!;
        }

        // Return the default value if the key doesn't exist or the parsing failed:
        return defaultValue;
    }

    public void Load()
    {
        // Get the path to the settings file:
        FileInfo settingsFile = GetUserApplicationPath();

        // Check if the settings file exists:
        if (settingsFile.Exists)
        {
            // Read the Json from the settings file:
            string json = File.ReadAllText(settingsFile.FullName);

            // Deserialize the Json to the settings dictionary:
            _settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json)!;
        }
    }

    public void Remove(string key) => _settings.Remove(key);

    public void Save()
    {
        // We serialize the settings dictionary with the JSon entries to Json:
        string json = JsonSerializer.Serialize(_settings);

        // Get the path to the settings file:
        FileInfo settingsFile = GetUserApplicationPath();

        // Write the Json to the settings file:
        File.WriteAllText(settingsFile.FullName, json);
    }

    public void Set<T>(string key, T value) where T : IParsable<T>
    {
        // Write the value to the settings dictionary as JSon:
        _settings[key] = JsonSerializer.Serialize(value);
    }

    public void SetArray<T>(string key, T[] value) where T : IParsable<T>
    {
        // Write the value to the settings dictionary as JSon:
        _settings[key] = JsonSerializer.Serialize(value);
    }
}
