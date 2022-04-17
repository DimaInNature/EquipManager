namespace EquipManager.Presentation.Views.UserControls.Menus;

public partial class DeleteMenuView : UserControl
{
    private readonly IDeleteMenuViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteMenuViewModel>();

    public DeleteMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(DeleteMenuViewModel));
    }
}