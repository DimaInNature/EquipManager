namespace EquipManager.Presentation.Models;

/// <summary> Модель с настройками состояния приложения.</summary>
internal static class ApplicationSettings
{
    /// <summary> Путь к конфигурационному файлу с настройками.</summary>
    public const string ConfigurationFilePath = @"appsettings.json";

    /// <summary> Тема приложения.</summary>
    /// <remarks> Список допустимых значений:
    /// <list type="bullet">
    /// <item><term>Light</term> Светлая тема.</item>
    /// <item><term>Dark</term> Тёмная тема.</item>
    /// </list>
    /// <term>По умолчанию</term> Light.
    /// </remarks>
    public static string Theme
    {
        get
        {
            const string defaultValue = "Light";

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            var result = DeserializeObject();

            return result is not null ? result.Theme : defaultValue;
        }
        set
        {
            SerializeObject(new Settings(theme: value, language: Language));

            if (_propsChanged < _propsCount) _propsChanged++;
            else SettingsChanged();
        }
    }

    /// <summary> Язык приложения.</summary>
    /// <remarks> Список допустимых значений:
    /// <list type="bullet">
    /// <item><term>Russian</term> Русский язык.</item>
    /// <item><term>English</term> Английский язык.</item>
    /// </list>
    /// <term>По умолчанию</term> Russian.
    /// </remarks>
    public static string Language
    {
        get
        {
            const string defaultValue = "Russian";

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            var result = DeserializeObject();

            return result is not null ? result.Language : defaultValue;
        }
        set
        {
            SerializeObject(new Settings(theme: Theme, language: value));

            if (_propsChanged < _propsCount) _propsChanged++;
            else SettingsChanged();
        }
    }

    private static byte _propsChanged = 0;
    private static readonly byte _propsCount = 0;

    private static readonly IMessageBoxService? _messageBox;

    static ApplicationSettings()
    {
        _messageBox = (Application.Current as App)?
            .ServiceProvider?.GetService<IMessageBoxService>();

        SettingsChanged += () =>
        {
            _messageBox?.Show(
                text: LanguageTranslator.Translate(key: "tm_ToApplyChangesYouNeedToRestartTheProgram"),
                caption: LanguageTranslator.Translate(key: "tm_Information"),
                icon: MessageBoxImage.Exclamation);

            Application.Current.Shutdown();
        };

        _propsCount = (byte)typeof(ApplicationSettings).GetProperties().Length;
    }

    public delegate void SettingsHandler();
    public static event SettingsHandler SettingsChanged;

    private static void SerializeObject(object obj)
    {
        JsonSerializer serializer = new() { NullValueHandling = NullValueHandling.Ignore };

        serializer.Converters.Add(item: new JavaScriptDateTimeConverter());

        using var stream = new StreamWriter(path: ConfigurationFilePath);

        using var writer = new JsonTextWriter(textWriter: stream);

        serializer.Serialize(jsonWriter: writer, value: obj);
    }

    private static Settings DeserializeObject()
    {
        string json = File.ReadAllText(path: ConfigurationFilePath);

        return JsonConvert.DeserializeObject<Settings>(value: json) ??
            throw new FileNotFoundException("Configuration file.");
    }

    [Serializable]
    private sealed record class Settings
    {
        public string Theme { get; init; }

        public string Language { get; init; }

        public Settings(string theme, string language) =>
            (Theme, Language) = (theme, language);
    }
}