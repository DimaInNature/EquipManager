namespace EquipManager.Presentation.ViewModels.UserControls.Menus;

internal sealed class SettingsMenuViewModel
    : BaseViewModel, ISettingsMenuViewModel
{
    #region Members

    public RelayCommand? ShowThemePageCommand { get; private set; }

    public RelayCommand? ShowLanguagePageCommand { get; private set; }

    public RelayCommand? ShowApplicationPageCommand { get; private set; }

    public RelayCommand? SetDefaultSettingsCommand { get; private set; }

    public object? FrameSource
    {
        get => _frameSource;
        set
        {
            _frameSource = value;

            OnPropertyChanged(nameof(FrameSource));

            MenuIsVisible = value switch
            {
                null => Visibility.Visible,
                _ => Visibility.Collapsed,
            };
        }
    }

    public Visibility FrameVisibility
    {
        get => _frameVisibility;
        set
        {
            _frameVisibility = value;

            OnPropertyChanged(nameof(FrameVisibility));
        }
    }

    public Visibility MenuIsVisible
    {
        get => _menuIsVisible;
        set
        {
            _menuIsVisible = value;

            OnPropertyChanged(nameof(MenuIsVisible));
        }
    }

    private object? _frameSource;

    private Visibility _frameVisibility;

    private Visibility _menuIsVisible;

    #endregion

    public SettingsMenuViewModel()
    {
        InitializeCommands();

        FrameSource = new ThemeSettingsView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowThemePage(object obj) =>
        FrameSource = new ThemeSettingsView();

    private void ExecuteShowLanguagePage(object obj) =>
        FrameSource = new LanguageSettingsView();

    private void ExecuteShowApplicationPage(object obj) =>
        FrameSource = new ApplicationSettingsView();

    private void ExecuteSetDefaultSettings(object obj) =>
        ApplicationSettingsManipulator.Default();

    #endregion

    #region CanExecute

    private bool CanExecuteShowThemePage(object obj) =>
        FrameSource is not ThemeSettingsView;

    private bool CanExecuteShowLanguagePage(object obj) =>
        FrameSource is not LanguageSettingsView;

    private bool CanExecuteShowApplicationPage(object obj) =>
        FrameSource is not ApplicationSettingsView;

    private bool CanExecuteSetDefaultSettings(object obj) => true;

    #endregion

    #endregion

    private void InitializeCommands()
    {
        ShowThemePageCommand = new(executeAction: ExecuteShowThemePage,
            canExecuteFunc: CanExecuteShowThemePage);

        ShowLanguagePageCommand = new(executeAction: ExecuteShowLanguagePage,
            canExecuteFunc: CanExecuteShowLanguagePage);

        ShowApplicationPageCommand = new(executeAction: ExecuteShowApplicationPage,
            canExecuteFunc: CanExecuteShowApplicationPage);

        SetDefaultSettingsCommand = new(executeAction: ExecuteSetDefaultSettings,
            canExecuteFunc: CanExecuteSetDefaultSettings);
    }
}