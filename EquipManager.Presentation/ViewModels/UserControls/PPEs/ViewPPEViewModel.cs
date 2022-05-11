namespace EquipManager.Presentation.ViewModels.UserControls.PPEs;

/// <summary> Модель представления для <see cref="ViewPPEView"/>.</summary>
internal sealed class ViewPPEViewModel
    : BaseViewModel, IViewModel<ViewPPEView>
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

    #region Commands

    public RelayCommand? LoadCommand { get; private set; }

    #endregion

    #region Private

    private IList<PPE> _ppes = new List<PPE>();

    #endregion

    #region Dependencies

    private readonly IPPEFacadeService _repository;

    #endregion

    #endregion

    public ViewPPEViewModel(IPPEFacadeService repository)
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