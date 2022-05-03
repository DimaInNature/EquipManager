namespace EquipManager.Presentation.Views.UserControls.Settings;

/// <summary> Представление.</summary>
public sealed partial class LanguageSettingsView : UserControl
{
    private readonly IViewModel<LanguageSettingsView>? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IViewModel<LanguageSettingsView>>();

    public LanguageSettingsView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(LanguageSettingsViewModel));
    }
}