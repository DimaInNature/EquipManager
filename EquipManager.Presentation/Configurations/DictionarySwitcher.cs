namespace EquipManager.Presentation.Configurations;

internal static class DictionarySwitcher
{
    public static void SwitchLanguage(string language)
    {
        ApplicationSettings.Language = language;

        Uri url = new(uriString: $"/Content/Languages/{language}.xaml", uriKind: UriKind.Relative);

        var resource = Application.LoadComponent(url) as ResourceDictionary;

        Application.Current.Resources.MergedDictionaries.Add(resource);
    }

    public static void SwitchTheme(string theme)
    {
        ApplicationSettings.Theme = theme;

        Application.Current.Resources.MergedDictionaries.Clear();

        Uri url = new(uriString: $"/Content/Theme/{theme}Theme.xaml", uriKind: UriKind.Relative);

        var resource = Application.LoadComponent(url) as ResourceDictionary;

        Application.Current.Resources.MergedDictionaries.Add(resource);
    }
}