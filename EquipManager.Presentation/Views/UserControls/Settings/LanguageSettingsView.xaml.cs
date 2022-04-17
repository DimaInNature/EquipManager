namespace EquipManager.Presentation.Views.UserControls.Settings;

public partial class LanguageSettingsView : UserControl
{
    private readonly ILanguageSettingsViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<ILanguageSettingsViewModel>();

    public LanguageSettingsView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ApplicationSettingsViewModel));
    }
}