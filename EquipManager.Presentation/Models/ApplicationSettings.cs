namespace EquipManager.Presentation.Models;

internal static class ApplicationSettings
{
    public const string ConfigurationFilePath = @"appsettings.json";

    public static string Theme
    {
        get
        {
            string defaultValue = "Light";

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<Settings>(value: json);

            return result is not null ? result.Theme : defaultValue;
        }
        set => SerializeObject(new Settings(theme: value, language: Language, topmost: Topmost));
    }

    public static string Language
    {
        get
        {
            string defaultValue = "Russian";

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<Settings>(value: json);

            return result is not null ? result.Language : defaultValue;
        }
        set => SerializeObject(new Settings(theme: Theme, language: value, topmost: Topmost));
    }

    public static bool Topmost
    {
        get
        {
            bool defaultValue = false;

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<Settings>(value: json);

            return result is not null ? result.Topmost : defaultValue;
        }
        set => SerializeObject(new Settings(theme: Theme, language: Language, topmost: value));
    }

    private static void SerializeObject(object obj)
    {
        JsonSerializer serializer = new() { NullValueHandling = NullValueHandling.Ignore };

        serializer.Converters.Add(item: new JavaScriptDateTimeConverter());

        using var stream = new StreamWriter(path: ConfigurationFilePath);

        using var writer = new JsonTextWriter(textWriter: stream);

        serializer.Serialize(jsonWriter: writer, value: obj);
    }

    [Serializable]
    private sealed record class Settings
    {
        public string Theme { get; init; }

        public string Language { get; init; }

        public bool Topmost { get; init; }

        public Settings(string theme, string language, bool topmost) =>
            (Theme, Language, Topmost) = (theme, language, topmost);
    }
}