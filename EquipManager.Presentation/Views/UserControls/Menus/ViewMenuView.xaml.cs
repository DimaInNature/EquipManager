namespace EquipManager.Presentation.Views.UserControls.Menus;

public partial class ViewMenuView : UserControl
{
    private readonly IViewMenuViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewMenuViewModel>();

    public ViewMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewMenuViewModel));
    }
}