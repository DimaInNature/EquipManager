namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

/// <summary> Представление.</summary>
public sealed partial class ExportPPEContractView : UserControl
{
    private readonly IViewModel<ExportPPEContractView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<ExportPPEContractView>>();

    public ExportPPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ExportPPEContractViewModel));
    }
}