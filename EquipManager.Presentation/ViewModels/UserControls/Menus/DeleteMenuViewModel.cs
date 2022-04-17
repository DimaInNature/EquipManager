namespace EquipManager.Presentation.ViewModels.UserControls.Menus;

internal sealed class DeleteMenuViewModel
    : BaseMenuViewModel, IDeleteMenuViewModel
{
    public DeleteMenuViewModel() => InitializeCommands();

    #region Command Logic

    #region Execute

    private void ExecuteShowEmployeePage(object obj) =>
        FrameSource = new DeleteEmployeeView();

    private void ExecuteShowPPEPage(object obj) =>
        FrameSource = new DeletePPEView();

    private void ExecuteShowPPEContractPage(object obj) =>
        FrameSource = new DeletePPEContractView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowEmployeePage(object obj) =>
        FrameSource is not DeleteEmployeeView;

    private bool CanExecuteShowPPEPage(object obj) =>
        FrameSource is not DeletePPEView;

    private bool CanExecuteShowPPEContractPage(object obj) =>
        FrameSource is not DeletePPEContractView;

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