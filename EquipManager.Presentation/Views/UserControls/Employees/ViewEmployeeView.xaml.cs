namespace EquipManager.Presentation.Views.UserControls.Employees;

public partial class ViewEmployeeView : UserControl
{
    private readonly IViewEmployeeViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewEmployeeViewModel>();

    public ViewEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewEmployeeViewModel));
    }
}