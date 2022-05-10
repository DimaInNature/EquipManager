namespace EquipManager.Presentation.Views;

/// <summary> Представление.</summary>
public sealed partial class MainView : Window
{
    private readonly IViewModel<MainView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<MainView>>();

    public MainView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(MainViewModel));
    }

    private void Window_MouseLeftDown(object sender, MouseButtonEventArgs e) => DragMove();

    private void MaximazedButton_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState switch
        {
            WindowState.Normal => WindowState.Maximized,
            _ => WindowState.Normal,
        };

    private void RollUpButton_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void ExitButton_Click(object sender, RoutedEventArgs e) =>
        Application.Current.Shutdown();

    private void HomeButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, HomeMenuButton.IsChecked) = ("TelPlus - Home", true);

        SetBody(control: HomeBody);
    }

    private void ViewButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, ViewMenuButton.IsChecked) = ("TelPlus - View", true);

        SetFrame(source: new ViewMenuView());
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, CreateMenuButton.IsChecked) = ("TelPlus - Create", true);

        SetFrame(source: new CreateMenuView());
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, UpdateMenuButton.IsChecked) = ("TelPlus - Update", true);

        SetFrame(source: new UpdateMenuView());
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, DeleteMenuButton.IsChecked) = ("TelPlus - Delete", true);

        SetFrame(source: new DeleteMenuView());
    }

    private void ExportButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, ExportMenuButton.IsChecked) = ("TelPlus - Export", true);

        SetBody(control: ExportBody);
    }

    private void SettingsButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, SettingsMenuButton.IsChecked) = ("TelPlus - Settings", true);

        SetFrame(source: new SettingsMenuView());
    }

    private void ExportPPEContractButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, ExportMenuButton.IsChecked) = ("TelPlus - Export", true);

        SetFrame(source: new ExportPPEContractView());
    }

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBodies();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void SetBody(Panel control)
    {
        CollapseFrame();

        CollapseBodies();

        control.Visibility = Visibility.Visible;
    }

    private void CollapseBodies() =>
        HomeBody.Visibility = ExportBody.Visibility = Visibility.Collapsed;

    private void CollapseFrame() =>
        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Collapsed, null);
}