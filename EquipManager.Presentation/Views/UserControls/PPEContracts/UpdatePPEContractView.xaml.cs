namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

/// <summary> Представление.</summary>
public sealed partial class UpdatePPEContractView : UserControl
{
    private readonly IViewModel<UpdatePPEContractView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<UpdatePPEContractView>>();

    public UpdatePPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(MainViewModel));
    }
}