namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

/// <summary> Представление.</summary>
public sealed partial class ViewPPEContractView : UserControl
{
    private readonly IViewModel<ViewPPEContractView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<ViewPPEContractView>>();

    public ViewPPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewPPEContractViewModel));
    }
}