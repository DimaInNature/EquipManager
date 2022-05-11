namespace EquipManager.Presentation.ViewModels.UserControls.PPEs;

/// <summary> Модель представления для <see cref="DeletePPEView"/>.</summary>
internal sealed class DeletePPEViewModel
    : BaseViewModel, IViewModel<DeletePPEView>
{
    #region Members

    public IList<PPE> PPEs
    {
        get => _ppes;
        set
        {
            _ppes = value is null
                ? new List<PPE>()
                : value;

            OnPropertyChanged(nameof(PPEs));
        }
    }

    public PPE? PPE
    {
        get => _ppe;
        set
        {
            _ppe = value;

            OnPropertyChanged(nameof(PPE));
        }
    }

    #region Commands

    public RelayCommand? LoadCommand { get; private set; }

    public RelayCommand? DeletePPECommand { get; private set; }

    #endregion

    #region Private

    private IList<PPE> _ppes = new List<PPE>();

    private PPE? _ppe;

    #endregion

    #region Dependencies

    private readonly IPPEFacadeService _repository;

    private readonly IMessageBoxService _messageBox;

    #endregion

    #endregion

    public DeletePPEViewModel(IPPEFacadeService repository,
       IMessageBoxService messageBox)
    {
        (_repository, _messageBox) = (repository, messageBox);

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteDeletePPE(object obj)
    {
        if (PPE is null) return;

        await _repository.DeleteAsync(id: PPE.Id);

        _messageBox.Show(
            text: LanguageTranslator.Translate(key: "tm_PPESuccessfullyDeleted"),
            caption: LanguageTranslator.Translate(key: "tm_Success"),
            icon: MessageBoxImage.Information);

        Clear();

        await LoadData();
    }

    private async void ExecuteLoad(object obj) => await LoadData();

    private bool CanExecuteDeletePPE(object obj) => PPE is not null;

    private bool CanExecuteLoad(object obj) => true;

    #endregion

    #region Other Logic

    private void InitializeCommand()
    {
        LoadCommand = new(executeAction: ExecuteLoad,
          canExecuteFunc: CanExecuteLoad);

        DeletePPECommand = new(executeAction: ExecuteDeletePPE,
           canExecuteFunc: CanExecuteDeletePPE);
    }

    private void Clear() => PPE = null;

    private async Task LoadData() =>
        PPEs = await _repository.GetPPEListAsync();

    #endregion
}