namespace EquipManager.Presentation.Views.UserControls.PPEs;

public partial class CreatePPEView : UserControl
{
    private readonly ICreatePPEViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<ICreatePPEViewModel>();

    public CreatePPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreatePPEViewModel));
    }
}