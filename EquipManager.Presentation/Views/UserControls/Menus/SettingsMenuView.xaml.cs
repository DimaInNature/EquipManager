namespace EquipManager.Presentation.Views.UserControls.Menus;

public partial class SettingsMenuView : UserControl
{
    private readonly ISettingsMenuViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ISettingsMenuViewModel>();

    public SettingsMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(SettingsMenuViewModel));
    }
}