namespace EquipManager.Presentation.Views.UserControls.PPEs;

/// <summary> Представление.</summary>
public sealed partial class CreatePPEView : UserControl
{
    private readonly IViewModel<CreatePPEView>? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IViewModel<CreatePPEView>>();

    public CreatePPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreatePPEViewModel));
    }
}