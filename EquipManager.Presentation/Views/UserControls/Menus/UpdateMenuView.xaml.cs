namespace EquipManager.Presentation.Views.UserControls.Menus;

public partial class UpdateMenuView : UserControl
{
    private readonly IUpdateMenuViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IUpdateMenuViewModel>();

    public UpdateMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(UpdateMenuViewModel));
    }
}