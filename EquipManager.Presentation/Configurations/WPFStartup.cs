namespace EquipManager.Presentation.Configurations;

/// <summary> Отвечает за установку состояния WPF клиента при его первом запуске.</summary>
internal static class WPFStartup
{
    /// <summary> Применяет настройки из конфигурацинного файла по адресу:
    /// <see cref="ApplicationSettings.ConfigurationFilePath"/>.</summary>
    public static void LoadState() => ApplicationSettingsManipulator.ApplySettings();

    /// <summary> Выполняет запуск стартового окна.</summary>
    public static void ShowWindow(Window startupWindow) => startupWindow.Show();
}