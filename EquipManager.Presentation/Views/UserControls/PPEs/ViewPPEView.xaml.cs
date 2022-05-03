namespace EquipManager.Presentation.Views.UserControls.PPEs;

/// <summary> Представление.</summary>
public sealed partial class ViewPPEView : UserControl
{
    private readonly IViewModel<ViewPPEView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<ViewPPEView>>();

    public ViewPPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewPPEViewModel));
    }
}