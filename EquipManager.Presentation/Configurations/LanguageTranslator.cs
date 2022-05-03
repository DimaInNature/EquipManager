namespace EquipManager.Presentation.Configurations;

internal static class LanguageTranslator
{
    private static readonly ResourceDictionary _dictionary;

    static LanguageTranslator()
    {
        _dictionary = new()
        {
            Source = new Uri(
                uriString: $"EquipManager.Presentation;component/Content/Languages/{ApplicationSettings.Language}.xaml",
                uriKind: UriKind.Relative)
        };
    }

    public static string Translate(string key) =>
        _dictionary[key: key] as string ?? string.Empty;
}