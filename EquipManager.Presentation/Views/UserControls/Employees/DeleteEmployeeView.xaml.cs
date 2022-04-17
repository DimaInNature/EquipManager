namespace EquipManager.Presentation.Views.UserControls.Employees;

public partial class DeleteEmployeeView : UserControl
{
    private readonly IDeleteEmployeeViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteEmployeeViewModel>();

    public DeleteEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(DeleteEmployeeViewModel));
    }
}