namespace EquipManager.Presentation.Views.UserControls.PPEs;

/// <summary> Представление.</summary>
public sealed partial class UpdatePPEView : UserControl
{
    private readonly IViewModel<UpdatePPEView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<UpdatePPEView>>();

    public UpdatePPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(UpdatePPEViewModel));
    }
}