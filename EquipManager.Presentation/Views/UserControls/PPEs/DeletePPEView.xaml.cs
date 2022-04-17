namespace EquipManager.Presentation.Views.UserControls.PPEs;

public partial class DeletePPEView : UserControl
{
    private readonly IDeletePPEViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeletePPEViewModel>();

    public DeletePPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(DeletePPEViewModel));
    }
}