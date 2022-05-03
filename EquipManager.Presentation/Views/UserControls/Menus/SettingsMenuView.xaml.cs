namespace EquipManager.Presentation.Views.UserControls.Menus;

/// <summary> Представление.</summary>
public sealed partial class SettingsMenuView : UserControl
{
    private readonly IViewModel<SettingsMenuView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<SettingsMenuView>>();

    public SettingsMenuView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(SettingsMenuViewModel));

        SetFrame(source: new ThemeSettingsView());
    }

    private void ThemeRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ThemeSettingsView());

    private void LanguageRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new LanguageSettingsView());

    private void SetFrame(ContentControl source) =>
        MenuFrame.Content = source ?? throw new NullReferenceException(nameof(source));
}