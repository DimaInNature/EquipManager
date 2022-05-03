namespace EquipManager.Presentation.ViewModels.UserControls.Settings;

/// <summary> Модель представления для <see cref="ThemeSettingsView"/>.</summary>
internal sealed class ThemeSettingsViewModel
    : BaseViewModel, IViewModel<ThemeSettingsView>
{
    public static string[] ThemeList => new string[] { "Light", "Dark" };

    public int SelectedThemeIndex
    {
        get => _selectedThemeIndex;
        set
        {
            if (value < 0) return;

            _selectedThemeIndex = value;

            OnPropertyChanged(nameof(SelectedThemeIndex));
        }
    }

    public RelayCommand? SelectThemeCommand { get; private set; }

    private int _selectedThemeIndex = 0;

    public ThemeSettingsViewModel()
    {
        InitializeCommands();

        SelectedThemeIndex = ApplicationSettings.Theme switch
        {
            "Light" => 0,
            "Dark" => 1,
            _ => 0,
        };
    }

    private void ExecuteSelectTheme(object obj)
    {
        ApplicationSettingsManipulator.ApplyTheme(
            theme: SelectedThemeIndex == 0 ? "Light" : "Dark");
    }

    private bool CanExecuteSelectTheme(object obj) => true;

    private void InitializeCommands()
    {
        SelectThemeCommand = new(executeAction: ExecuteSelectTheme,
            canExecuteFunc: CanExecuteSelectTheme);
    }
}