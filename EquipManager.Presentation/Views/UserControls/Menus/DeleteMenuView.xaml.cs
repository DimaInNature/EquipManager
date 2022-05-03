namespace EquipManager.Presentation.Views.UserControls.Menus;

/// <summary> Представление.</summary>
public sealed partial class DeleteMenuView : UserControl
{
    private readonly IViewModel<DeleteMenuView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<DeleteMenuView>>();

    public DeleteMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(DeleteMenuViewModel));
    }

    private void EmployeeButton_Click(object sender, RoutedEventArgs e) =>
      SetFrame(source: new DeleteEmployeeView());

    private void PPEButton_Click(object sender, RoutedEventArgs e) =>
         SetFrame(source: new DeletePPEView());

    private void ContractButton_Click(object sender, RoutedEventArgs e) =>
         SetFrame(source: new DeletePPEContractView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}