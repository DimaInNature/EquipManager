namespace EquipManager.Presentation.Views.UserControls.PPEs;

public partial class ViewPPEView : UserControl
{
    private readonly IViewPPEViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewPPEViewModel>();

    public ViewPPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewPPEViewModel));
    }
}