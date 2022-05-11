namespace EquipManager.Presentation.ViewModels.UserControls.PPEContracts;

/// <summary> Модель представления для <see cref="DeletePPEContractView"/>.</summary>
internal sealed class DeletePPEContractViewModel
    : BaseViewModel, IViewModel<DeletePPEContractView>
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

    public RelayCommand? DeletePPEContractCommand { get; private set; }

    #endregion

    #region Private

    private IList<PPEContract> _ppeContracts = new List<PPEContract>();

    private PPEContract? _ppeContract;

    #endregion

    #region Dependencies

    private readonly IPPEContractFacadeService _repository;

    private readonly IMessageBoxService _messageBox;

    #endregion

    #endregion

    public DeletePPEContractViewModel(IPPEContractFacadeService repository,
        IMessageBoxService messageBox)
    {
        (_repository, _messageBox) = (repository, messageBox);

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteLoad(object obj) => await LoadData();

    private async void ExecuteDeletePPEContract(object obj)
    {
        if (PPEContract is null) return;

        await _repository.DeleteAsync(PPEContract.Id);

        _messageBox.Show(
            text: LanguageTranslator.Translate(key: "tm_ContractSuccessfullyDeleted"),
            caption: LanguageTranslator.Translate(key: "tm_Success"),
            icon: MessageBoxImage.Information);

        Clear();

        await LoadData();
    }

    private bool CanExecuteLoad(object obj) => true;

    private bool CanExecuteDeletePPEContract(object obj) => PPEContract is not null;

    #endregion

    #region Other Logic

    private void InitializeCommand()
    {
        LoadCommand = new(executeAction: ExecuteLoad,
         canExecuteFunc: CanExecuteLoad);

        DeletePPEContractCommand = new(executeAction: ExecuteDeletePPEContract,
            canExecuteFunc: CanExecuteDeletePPEContract);
    }

    private void Clear() => PPEContract = null;

    private async Task LoadData() =>
        PPEContracts = await _repository.GetPPEContractListAsync();

    #endregion
}