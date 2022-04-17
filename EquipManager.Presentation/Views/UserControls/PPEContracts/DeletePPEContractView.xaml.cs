namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

public partial class DeletePPEContractView : UserControl
{
    private readonly IDeletePPEContractViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeletePPEContractViewModel>();

    public DeletePPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(DeletePPEContractViewModel));
    }
}