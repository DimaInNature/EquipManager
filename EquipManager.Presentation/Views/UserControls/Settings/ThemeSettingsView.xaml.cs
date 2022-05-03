namespace EquipManager.Presentation.Views.UserControls.Settings;

/// <summary> Представление.</summary>
public sealed partial class ThemeSettingsView : UserControl
{
    private readonly IViewModel<ThemeSettingsView>? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IViewModel<ThemeSettingsView>>();

    public ThemeSettingsView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ThemeSettingsViewModel));
    }
}