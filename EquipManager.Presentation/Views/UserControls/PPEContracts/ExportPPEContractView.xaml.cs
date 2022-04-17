namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

public partial class ExportPPEContractView : UserControl
{
    private readonly IExportPPEContractViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IExportPPEContractViewModel>();

    public ExportPPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ExportPPEContractViewModel));
    }
}