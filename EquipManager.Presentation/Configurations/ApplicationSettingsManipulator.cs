namespace EquipManager.Presentation.Configurations;

internal static class ApplicationSettingsManipulator
{
    private const string DefaultTheme = "Light";
    private const string DefaultLanguage = "Russian";
    private const bool DefaultTopmost = false;

    public static void ApplySettings(string theme, string language, bool topmost)
    {
        DictionarySwitcher.SwitchTheme(theme);
        DictionarySwitcher.SwitchLanguage(language);
        ApplicationSettings.Topmost = topmost;
    }

    public static void ApplyTheme(string theme)
    {
        DictionarySwitcher.SwitchTheme(theme);
        DictionarySwitcher.SwitchLanguage(ApplicationSettings.Language);
    }

    public static void ApplyLanguage(string language)
    {
        DictionarySwitcher.SwitchLanguage(language);
    }

    public static void Default() =>
        ApplySettings(DefaultTheme, DefaultLanguage, DefaultTopmost);
}