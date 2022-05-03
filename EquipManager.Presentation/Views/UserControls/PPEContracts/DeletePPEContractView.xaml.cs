namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

/// <summary> Представление.</summary>
public sealed partial class DeletePPEContractView : UserControl
{
    private readonly IViewModel<DeletePPEContractView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<DeletePPEContractView>>();

    public DeletePPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(DeletePPEContractViewModel));
    }
}