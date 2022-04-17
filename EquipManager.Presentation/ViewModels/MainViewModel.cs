namespace EquipManager.Presentation.ViewModels;

internal sealed class MainViewModel
    : BaseViewModel, IMainViewModel
{
    #region Members

    #region Commands

    public RelayCommand? ShowHomePageCommand { get; private set; }

    public RelayCommand? ShowViewMenuPageCommand { get; private set; }

    public RelayCommand? ShowCreateMenuPageCommand { get; private set; }

    public RelayCommand? ShowUpdateMenuPageCommand { get; private set; }

    public RelayCommand? ShowDeleteMenuPageCommand { get; private set; }

    public RelayCommand? ShowExportMenuPageCommand { get; private set; }

    public RelayCommand? ShowSettingsMenuPageCommand { get; private set; }

    public RelayCommand? ShowCreateEmployeePageCommand { get; private set; }

    public RelayCommand? ShowCreatePPEContractPageCommand { get; private set; }

    #endregion

    #region View

    public Visibility FrameVisibility
    {
        get => _frameVisibility;
        set
        {
            _frameVisibility = value;
            OnPropertyChanged(nameof(FrameVisibility));
        }
    }

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

    public Visibility MenuIsVisible
    {
        get => _menuIsVisible;
        set
        {
            _menuIsVisible = value;
            OnPropertyChanged(nameof(MenuIsVisible));
        }
    }

    #endregion

    #region Private

    private Visibility _frameVisibility;

    private object? _frameSource;

    private Visibility _menuIsVisible;

    #endregion

    #endregion

    public MainViewModel() => InitializeCommands();

    #region Command Logic

    #region Execute

    private void ExecuteShowViewMenuPage(object obj) =>
        FrameSource = new ViewMenuView();

    private void ExecuteShowHomePage(object obj) =>
        FrameSource = null;

    private void ExecuteShowUpdateMenuPage(object obj) =>
        FrameSource = new UpdateMenuView();

    private void ExecuteShowCreateMenuPage(object obj) =>
        FrameSource = new CreateMenuView();

    private void ExecuteShowDeleteMenuPage(object obj) =>
        FrameSource = new DeleteMenuView();

    private void ExecuteShowExportMenuPage(object obj) =>
        FrameSource = new ExportMenuView();

    private void ExecuteShowSettingMenuPage(object obj) =>
        FrameSource = new SettingsMenuView();

    private void ExecuteShowCreateEmployeePage(object obj) =>
       FrameSource = new CreateEmployeeView();

    private void ExecuteShowCreatePPEContractPage(object obj) =>
       FrameSource = new CreatePPEContractView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowHomePage(object obj) =>
        !(FrameSource is null && MenuIsVisible is Visibility.Visible);

    private bool CanExecuteShowViewMenuPage(object obj) =>
        FrameSource is not ViewMenuView;

    private bool CanExecuteShowUpdateMenuPage(object obj) =>
        FrameSource is not UpdateMenuView;

    private bool CanExecuteShowCreateMenuPage(object obj) =>
        FrameSource is not CreateMenuView;

    private bool CanExecuteShowDeleteMenuPage(object obj) =>
        FrameSource is not DeleteMenuView;

    private bool CanExecuteShowExportMenuPage(object obj) =>
        FrameSource is not ExportMenuView;

    private bool CanExecuteShowSettingsMenuPage(object obj) =>
        FrameSource is not SettingsMenuView;

    private bool CanExecuteShowCreateEmployeePage(object obj) =>
        FrameSource is not CreateEmployeeView;

    private bool CanExecuteShowCreatePPEContractPage(object obj) =>
        FrameSource is not CreatePPEContractView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowHomePageCommand = new(executeAction: ExecuteShowHomePage,
            canExecuteFunc: CanExecuteShowHomePage);

        ShowViewMenuPageCommand = new(executeAction: ExecuteShowViewMenuPage,
            canExecuteFunc: CanExecuteShowViewMenuPage);

        ShowCreateMenuPageCommand = new(executeAction: ExecuteShowCreateMenuPage,
           canExecuteFunc: CanExecuteShowCreateMenuPage);

        ShowUpdateMenuPageCommand = new(executeAction: ExecuteShowUpdateMenuPage,
            canExecuteFunc: CanExecuteShowUpdateMenuPage);

        ShowDeleteMenuPageCommand = new(executeAction: ExecuteShowDeleteMenuPage,
            canExecuteFunc: CanExecuteShowDeleteMenuPage);

        ShowExportMenuPageCommand = new(executeAction: ExecuteShowExportMenuPage,
            canExecuteFunc: CanExecuteShowExportMenuPage);

        ShowSettingsMenuPageCommand = new(executeAction: ExecuteShowSettingMenuPage,
            canExecuteFunc: CanExecuteShowSettingsMenuPage);

        ShowCreateEmployeePageCommand = new(executeAction: ExecuteShowCreateEmployeePage,
            canExecuteFunc: CanExecuteShowCreateEmployeePage);

        ShowCreatePPEContractPageCommand = new(executeAction: ExecuteShowCreatePPEContractPage,
            canExecuteFunc: CanExecuteShowCreatePPEContractPage);
    }

    #endregion
}