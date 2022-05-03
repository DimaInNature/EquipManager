namespace EquipManager.Presentation.Views.UserControls.PPEs;

/// <summary> Представление.</summary>
public sealed partial class DeletePPEView : UserControl
{
    private readonly IViewModel<DeletePPEView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<DeletePPEView>>();

    public DeletePPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(DeletePPEViewModel));
    }
}