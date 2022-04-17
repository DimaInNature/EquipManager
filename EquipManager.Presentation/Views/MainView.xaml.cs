namespace EquipManager.Presentation.Views;

public partial class MainView : Window
{
    private readonly IMainViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IMainViewModel>();

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

    private void ShowViewMenuPageButton_Click(object sender, RoutedEventArgs e) =>
        (Title, ViewMenuButton.IsChecked) = ("TelPlus - View", true);

    private void ShowCreateMenuPageButton_Click(object sender, RoutedEventArgs e) =>
        (Title, CreateMenuButton.IsChecked) = ("TelPlus - Create", true);

    private void ShowUpdateMenuPageButton_Click(object sender, RoutedEventArgs e) =>
        (Title, UpdateMenuButton.IsChecked) = ("TelPlus - Update", true);

    private void ShowDeleteMenuPageButton_Click(object sender, RoutedEventArgs e) =>
        (Title, DeleteMenuButton.IsChecked) = ("TelPlus - Delete", true);

    private void HomeMenuButton_Click(object sender, RoutedEventArgs e) => Title = "TelPlus - Home";

    private void ViewMenuButton_Click(object sender, RoutedEventArgs e) => Title = "TelPlus - View";

    private void CreateMenuButton_Click(object sender, RoutedEventArgs e) => Title = "TelPlus - Create";

    private void UpdateMenuButton_Click(object sender, RoutedEventArgs e) => Title = "TelPlus - Update";

    private void DeleteMenuButton_Click(object sender, RoutedEventArgs e) => Title = "TelPlus - Delete";

    private void ExportMenuButton_Click(object sender, RoutedEventArgs e) => Title = "TelPlus - Export";

    private void SettingsMenuButton_Click(object sender, RoutedEventArgs e) => Title = "TelPlus - Settings";
}