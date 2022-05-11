namespace EquipManager.Presentation.ViewModels.UserControls.PPEContracts;

/// <summary> Модель представления для <see cref="ExportPPEContractView"/>.</summary>
internal sealed class ExportPPEContractViewModel
    : BaseViewModel, IViewModel<ExportPPEContractView>
{
    #region Members

    public IList<PPEContract> PPEContracts
    {
        get => _ppeContracts;
        set
        {
            _ppeContracts = value is null
                ? new List<PPEContract>()
                : value;
            OnPropertyChanged(nameof(PPEContracts));
        }
    }

    public PPEContract? PPEContract
    {
        get => _ppeContract;
        set
        {
            _ppeContract = value;

            OnPropertyChanged(nameof(PPEContract));
        }
    }

    #region Commands

    public RelayCommand? LoadCommand { get; private set; }

    public RelayCommand? ExportPPEContractCommand { get; private set; }

    #endregion

    #region Private

    private IList<PPEContract> _ppeContracts = new List<PPEContract>();

    private PPEContract? _ppeContract;

    #endregion

    #region Dependencies

    private readonly IPPEContractFacadeService _repository;

    private readonly IMessageBoxService _messageBox;

    private readonly WordDocumentService _wordService;

    #endregion

    #endregion

    public ExportPPEContractViewModel(IPPEContractFacadeService repository,
        IMessageBoxService messageBox, WordDocumentService wordService)
    {
        (_repository, _messageBox, _wordService) = (repository, messageBox, wordService);

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteLoad(object obj) =>
        PPEContracts = await _repository.GetPPEContractListAsync();

    private void ExecuteExportPPEContract(object obj)
    {
        if (PPEContract is null) return;

        if (PPEContract.Employee is null) return;

        if (_wordService.Process(contract: PPEContract))
        {
            _messageBox.Show(
                text: LanguageTranslator.Translate(key: "tm_ContractSuccessfullyExported"),
                caption: LanguageTranslator.Translate(key: "tm_Success"),
                icon: MessageBoxImage.Information);

            Clear();
        }
    }

    private bool CanExecuteLoad(object obj) => true;

    private bool CanExecuteExportPPEContract(object obj) => PPEContract is not null;

    #endregion

    #region Other Logic

    private void InitializeCommand()
    {
        LoadCommand = new(executeAction: ExecuteLoad,
            canExecuteFunc: CanExecuteLoad);

        ExportPPEContractCommand = new(executeAction: ExecuteExportPPEContract,
           canExecuteFunc: CanExecuteExportPPEContract);
    }

    private void Clear() => PPEContract = null;

    #endregion
}