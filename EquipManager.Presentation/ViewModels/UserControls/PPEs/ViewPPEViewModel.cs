namespace EquipManager.Presentation.ViewModels.UserControls.PPEs;

/// <summary> Модель представления для <see cref="ViewPPEView"/>.</summary>
internal sealed class ViewPPEViewModel
    : BaseViewModel, IViewModel<ViewPPEView>
{
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

    private IList<PPE> _ppes = new List<PPE>();

    private readonly IPPEFacadeService _repository;

    public ViewPPEViewModel(IPPEFacadeService repository)
    {
        _repository = repository;

        Task.Run(LoadData);
    }

    private async void LoadData() =>
        PPEs = await _repository.GetPPEListAsync();
}