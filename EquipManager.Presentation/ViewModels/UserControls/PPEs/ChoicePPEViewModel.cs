namespace EquipManager.Presentation.ViewModels.UserControls.PPEs;

/// <summary> Модель представления для <see cref="ChoicePPEView"/>.</summary>
internal sealed class ChoicePPEViewModel
    : BaseViewModel, IViewModel<ChoicePPEView>
{
    #region Members

    public List<PPE> PPEs
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

    #endregion

    #region Private

    private List<PPE> _ppes = new();

    private PPE? _ppe;

    #endregion

    #region Dependencies

    private readonly IPPEFacadeService _repository;

    #endregion

    #endregion

    public ChoicePPEViewModel(IPPEFacadeService repository)
    {
        _repository = repository;

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteLoad(object obj) =>
        PPEs = await _repository.GetPPEListAsync();

    private bool CanExecuteLoad(object obj) => true;

    #endregion

    #region Other Logic

    private void InitializeCommand()
    {
        LoadCommand = new(executeAction: ExecuteLoad,
            canExecuteFunc: CanExecuteLoad);
    }

    #endregion
}