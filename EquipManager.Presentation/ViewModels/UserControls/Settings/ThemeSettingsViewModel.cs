namespace EquipManager.Presentation.ViewModels.UserControls.Settings;

internal sealed class ThemeSettingsViewModel
    : BaseViewModel, IThemeSettingsViewModel
{
    public string[] ThemeList => new string[] { "Light", "Dark" };

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

    private void ExecuteSelectTheme(object obj) =>
        ApplicationSettingsManipulator.ApplyTheme(SelectedThemeIndex == 0 ? "Light" : "Dark");

    private bool CanExecuteSelectTheme(object obj) => true;

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

    private void InitializeCommands()
    {
        SelectThemeCommand = new(executeAction: ExecuteSelectTheme,
            canExecuteFunc: CanExecuteSelectTheme);
    }
}