namespace EquipManager.Presentation.ViewModels.UserControls.Menus;

internal class UpdateMenuViewModel
    : BaseMenuViewModel, IUpdateMenuViewModel
{
    public UpdateMenuViewModel() => InitializeCommands();

    #region Command Logic

    #region Execute

    private void ExecuteShowEmployeePage(object obj) =>
        FrameSource = new UpdateEmployeeView();

    private void ExecuteShowPPEPage(object obj) =>
        FrameSource = new UpdatePPEView();

    private void ExecuteShowPPEContractPage(object obj) =>
        FrameSource = new UpdatePPEContractView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowEmployeePage(object obj) =>
        FrameSource is not UpdateEmployeeView;

    private bool CanExecuteShowPPEPage(object obj) =>
        FrameSource is not UpdatePPEView;

    private bool CanExecuteShowPPEContractPage(object obj) =>
        FrameSource is not UpdatePPEContractView;

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