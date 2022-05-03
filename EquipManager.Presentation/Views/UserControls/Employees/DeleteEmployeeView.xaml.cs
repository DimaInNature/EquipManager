namespace EquipManager.Presentation.Views.UserControls.Employees;

/// <summary> Представление.</summary>
public sealed partial class DeleteEmployeeView : UserControl
{
    private readonly IViewModel<DeleteEmployeeView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<DeleteEmployeeView>>();

    public DeleteEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(DeleteEmployeeViewModel));
    }
}