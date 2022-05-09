namespace EquipManager.Presentation.Views.UserControls.Employees;

/// <summary> Представление.</summary>
public partial class ChoiceEmployeeView : UserControl
{
    public Employee? SelectedEmployee => (DataContext as ChoiceEmployeeViewModel)?.Employee;

    private readonly IViewModel<ChoiceEmployeeView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<ChoiceEmployeeView>>();

    public ChoiceEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreatePPEContractViewModel));
    }

    public void Clear()
    {
        if (DataContext is null) return;

        (DataContext as ChoiceEmployeeViewModel).Employee = null;
    }
}