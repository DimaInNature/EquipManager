namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

public partial class UpdatePPEContractView : UserControl
{
    private readonly IUpdatePPEContractViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IUpdatePPEContractViewModel>();

    public UpdatePPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(MainViewModel));
    }
}