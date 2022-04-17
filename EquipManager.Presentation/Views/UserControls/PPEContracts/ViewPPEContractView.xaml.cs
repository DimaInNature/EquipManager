namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

public partial class ViewPPEContractView : UserControl
{
    private readonly IViewPPEContractViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewPPEContractViewModel>();

    public ViewPPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewPPEContractViewModel));
    }
}