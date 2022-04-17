namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

public partial class CreatePPEContractView : UserControl
{
    private readonly ICreatePPEContractViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreatePPEContractViewModel>();

    public CreatePPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreatePPEContractViewModel));
    }
}