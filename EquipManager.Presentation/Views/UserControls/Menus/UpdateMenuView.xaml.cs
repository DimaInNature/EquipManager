namespace EquipManager.Presentation.Views.UserControls.Menus;

/// <summary> Представление.</summary>
public sealed partial class UpdateMenuView : UserControl
{
    private readonly IViewModel<UpdateMenuView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<UpdateMenuView>>();

    public UpdateMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(UpdateMenuViewModel));
    }

    private void EmployeeButton_Click(object sender, RoutedEventArgs e) =>
     SetFrame(source: new UpdateEmployeeView());

    private void PPEButton_Click(object sender, RoutedEventArgs e) =>
         SetFrame(source: new UpdatePPEView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}