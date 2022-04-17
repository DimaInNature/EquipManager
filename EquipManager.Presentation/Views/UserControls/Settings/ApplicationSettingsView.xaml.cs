namespace EquipManager.Presentation.Views.UserControls.Settings;

public partial class ApplicationSettingsView : UserControl
{
    private readonly IApplicationSettingsViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IApplicationSettingsViewModel>();

    public ApplicationSettingsView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ApplicationSettingsViewModel));
    }
}