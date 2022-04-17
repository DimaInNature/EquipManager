namespace EquipManager.Presentation.Views.UserControls.Employees;

public partial class CreateEmployeeView : UserControl
{
    private readonly ICreateEmployeeViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreateEmployeeViewModel>();

    public CreateEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreateEmployeeViewModel));
    }
}