namespace EquipManager.Presentation.ViewModels.UserControls.PPEContracts;

/// <summary> Модель представления для <see cref="ViewPPEContractView"/>.</summary>
internal sealed class ViewPPEContractViewModel
    : BaseViewModel, IViewModel<ViewPPEContractView>
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

    #endregion

    #region Private

    private IList<PPEContract> _ppeContracts = new List<PPEContract>();

    private PPEContract? _ppeContract;

    #endregion

    #region Dependencies

    private readonly IPPEContractFacadeService _repository;

    #endregion

    #endregion

    public ViewPPEContractViewModel(IPPEContractFacadeService repository)
    {
        _repository = repository;

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteLoad(object obj) =>
        PPEContracts = await _repository.GetPPEContractListAsync();

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