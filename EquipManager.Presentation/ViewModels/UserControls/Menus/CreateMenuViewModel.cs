namespace EquipManager.Presentation.ViewModels.UserControls.Menus;

internal sealed class CreateMenuViewModel
    : BaseMenuViewModel, ICreateMenuViewModel
{
    public CreateMenuViewModel() => InitializeCommands();

    #region Command Logic

    #region Execute

    private void ExecuteShowEmployeePage(object obj) =>
        FrameSource = new CreateEmployeeView();

    private void ExecuteShowPPEPage(object obj) =>
        FrameSource = new CreatePPEView();

    private void ExecuteShowPPEContractPage(object obj) =>
        FrameSource = new CreatePPEContractView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowEmployeePage(object obj) =>
        FrameSource is not CreateEmployeeView;

    private bool CanExecuteShowPPEPage(object obj) =>
        FrameSource is not CreatePPEView;

    private bool CanExecuteShowPPEContractPage(object obj) =>
        FrameSource is not CreatePPEContractView;

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