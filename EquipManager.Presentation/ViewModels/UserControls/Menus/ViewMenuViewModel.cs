namespace EquipManager.Presentation.ViewModels.UserControls.Menus;

internal sealed class ViewMenuViewModel
    : BaseMenuViewModel, IViewMenuViewModel
{
    public ViewMenuViewModel() => InitializeCommands();

    #region Command Logic

    #region Execute

    private void ExecuteShowEmployeePage(object obj) =>
        FrameSource = new ViewEmployeeView();

    private void ExecuteShowPPEPage(object obj) =>
        FrameSource = new ViewPPEView();

    private void ExecuteShowPPEContractPage(object obj) =>
        FrameSource = new ViewPPEContractView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowEmployeePage(object obj) =>
        FrameSource is not ViewEmployeeView;

    private bool CanExecuteShowPPEPage(object obj) =>
        FrameSource is not ViewPPEView;

    private bool CanExecuteShowPPEContractPage(object obj) =>
        FrameSource is not ViewPPEContractView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowEmployeePageCommand = new(executeAction: ExecuteShowEmployeePage,
          canExecuteFunc: CanExecuteShowEmployeePage);

        ShowPPEPageCommand = new(executeAction: ExecuteShowPPEPage,
            canExecuteFunc: CanExecuteShowPPEPage);

        ShowPPEContractPageCommand = new(executeAction: ExecuteShowPPEContractPage,
            canExecuteFunc: CanExecuteShowPPEContractPage);
    }

    #endregion
}