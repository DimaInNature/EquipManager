namespace EquipManager.Presentation.Views.UserControls.Menus;

public partial class ExportMenuView : UserControl
{
    private readonly IExportMenuViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IExportMenuViewModel>();

    public ExportMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ExportMenuViewModel));
    }
}