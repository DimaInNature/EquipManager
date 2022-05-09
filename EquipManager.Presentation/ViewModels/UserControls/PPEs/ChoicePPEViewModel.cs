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

    #region Private

    private List<PPE> _ppes = new();

    private PPE? _ppe;

    #endregion

    #region Dependencies

    private readonly IPPEFacadeService _repository;

    #endregion

    private static readonly SemaphoreSlim _semaphore = new(initialCount: 1, maxCount: 1);

    #endregion

    public ChoicePPEViewModel(IPPEFacadeService repository)
    {
        _repository = repository;

        Task.Run(action: LoadData);
    }

    private async void LoadData()
    {
        await _semaphore.WaitAsync();

        try
        {
            PPEs = await _repository.GetPPEListAsync();
        }
        finally
        {
            _semaphore.Release();
        }
    }
}