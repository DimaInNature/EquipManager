namespace EquipManager.Presentation.Views.UserControls.Menus;

/// <summary> Представление.</summary>
public sealed partial class ViewMenuView : UserControl
{
    private readonly IViewModel<ViewMenuView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<ViewMenuView>>();

    public ViewMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewMenuViewModel));
    }

    private void EmployeeButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ViewEmployeeView());

    private void PPEButton_Click(object sender, RoutedEventArgs e) =>
         SetFrame(source: new ViewPPEView());

    private void ContractButton_Click(object sender, RoutedEventArgs e) =>
         SetFrame(source: new ViewPPEContractView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}