namespace EquipManager.Presentation.ViewModels.UserControls.PPEContracts;

/// <summary> Модель представления для <see cref="ViewPPEContractView"/>.</summary>
internal sealed class ViewPPEContractViewModel
    : BaseViewModel, IViewModel<ViewPPEContractView>
{
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

    private IList<PPEContract> _ppeContracts = new List<PPEContract>();

    private PPEContract? _ppeContract;

    private readonly IPPEContractFacadeService _repository;

    public ViewPPEContractViewModel(IPPEContractFacadeService repository)
    {
        _repository = repository;

        Task.Run(action: LoadData);
    }

    private async void LoadData() =>
        PPEContracts = await _repository.GetPPEContractListAsync();
}