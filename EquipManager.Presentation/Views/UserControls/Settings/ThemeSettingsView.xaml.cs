namespace EquipManager.Presentation.Views.UserControls.Settings;

public partial class ThemeSettingsView : UserControl
{
    private readonly IThemeSettingsViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IThemeSettingsViewModel>();

    public ThemeSettingsView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ThemeSettingsViewModel));
    }
}