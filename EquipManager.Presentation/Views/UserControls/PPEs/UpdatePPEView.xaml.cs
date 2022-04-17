namespace EquipManager.Presentation.Views.UserControls.PPEs;

public partial class UpdatePPEView : UserControl
{
    private readonly IUpdatePPEViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IUpdatePPEViewModel>();

    public UpdatePPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(UpdatePPEViewModel));
    }
}