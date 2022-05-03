namespace EquipManager.Presentation.Views.UserControls.Employees;

/// <summary> Представление.</summary>
public sealed partial class CreateEmployeeView : UserControl
{
    private readonly IViewModel<CreateEmployeeView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<CreateEmployeeView>>();

    public CreateEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreateEmployeeViewModel));
    }
}