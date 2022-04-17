namespace EquipManager.Presentation.Views.UserControls.Employees;

public partial class UpdateEmployeeView : UserControl
{
    private readonly IUpdateEmployeeViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IUpdateEmployeeViewModel>();

    public UpdateEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(UpdateEmployeeViewModel));
    }
}