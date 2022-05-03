namespace EquipManager.Presentation.Views.UserControls.Menus;

/// <summary> Представление.</summary>
public sealed partial class CreateMenuView : UserControl
{
    private readonly IViewModel<CreateMenuView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<CreateMenuView>>();

    public CreateMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreateMenuViewModel));
    }

    private void EmployeeButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateEmployeeView());

    private void PPEButton_Click(object sender, RoutedEventArgs e) =>
         SetFrame(source: new CreatePPEView());

    private void ContractButton_Click(object sender, RoutedEventArgs e) =>
         SetFrame(source: new CreatePPEContractView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}