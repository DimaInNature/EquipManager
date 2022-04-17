namespace EquipManager.Presentation.Views.UserControls.Menus;

public partial class CreateMenuView : UserControl
{
    private readonly ICreateMenuViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreateMenuViewModel>();

    public CreateMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreateMenuViewModel)); ;
    }
}