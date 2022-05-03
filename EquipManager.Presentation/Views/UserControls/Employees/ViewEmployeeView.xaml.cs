namespace EquipManager.Presentation.Views.UserControls.Employees;

/// <summary> Представление.</summary>
public sealed partial class ViewEmployeeView : UserControl
{
    private readonly IViewModel<ViewEmployeeView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<ViewEmployeeView>>();

    public ViewEmployeeView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewEmployeeViewModel));
    }
}