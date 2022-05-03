namespace EquipManager.Presentation.Configurations;

internal static class ApplicationSettingsManipulator
{
    private const string DefaultTheme = "Light";

    private const string DefaultLanguage = "Russian";

    public static void ApplySettings()
    {
        DictionarySwitcher.SwitchTheme(theme: ApplicationSettings.Theme);

        DictionarySwitcher.SwitchLanguage(language: ApplicationSettings.Language);
    }

    public static void ApplyTheme(string theme)
    {
        ApplicationSettings.Theme = theme;
    }

    public static void ApplyLanguage(string language)
    {
        ApplicationSettings.Language = language;
    }

    public static void Default()
    {
        ApplicationSettings.Theme = DefaultTheme;

        ApplicationSettings.Language = DefaultLanguage;
    }
}