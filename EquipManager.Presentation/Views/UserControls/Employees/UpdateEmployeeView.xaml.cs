namespace EquipManager.Presentation.Views.UserControls.Employees;

/// <summary> Представление.</summary>
public sealed partial class UpdateEmployeeView : UserControl
{
    private readonly IViewModel<UpdateEmployeeView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<UpdateEmployeeView>>();

    public UpdateEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(UpdateEmployeeViewModel));
    }
}