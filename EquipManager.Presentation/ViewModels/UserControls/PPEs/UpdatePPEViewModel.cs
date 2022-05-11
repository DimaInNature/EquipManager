namespace EquipManager.Presentation.ViewModels.UserControls.PPEs;

/// <summary> Модель представления для <see cref="UpdatePPEView"/>.</summary>
internal sealed class UpdatePPEViewModel
    : BaseViewModel, IViewModel<UpdatePPEView>
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

    public RelayCommand? UpdatePPECommand { get; private set; }

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

    public UpdatePPEViewModel(IPPEFacadeService repository,
       IMessageBoxService messageBox)
    {
        (_repository, _messageBox) = (repository, messageBox);

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteLoad(object obj) => await LoadData();

    private async void ExecuteUpdatePPE(object obj)
    {
        if (PPE is null) return;

        var ppe = PPE.GetBuilder()
            .SetName(PPE.Name)
            .SetQuantityPerYear(PPE.QuantityPerYear)
            .SetUnitOfMeasurement(PPE.UnitOfMeasurement)
            .SetCertificateOfConformity(PPE.CertificateOfConformity)
            .Build();

        await _repository.UpdateAsync(ppe);

        _messageBox.Show(
            text: LanguageTranslator.Translate(key: "tm_PPESuccessfullyUpdated"),
            caption: LanguageTranslator.Translate(key: "tm_Success"),
            icon: MessageBoxImage.Information);

        Clear();
    }

    private bool CanExecuteLoad(object obj) => true;

    private bool CanExecuteUpdatePPE(object obj)
    {
        if (PPE is null) return false;

        string[] textProps = { PPE.Name, PPE.UnitOfMeasurement, PPE.CertificateOfConformity };

        int?[] digitProps = { PPE.QuantityPerYear };

        return textProps.IsNotNullOrWhiteSpace() && digitProps.IsPositive();
    }

    #endregion

    #region Other Logic

    private void InitializeCommand()
    {
        LoadCommand = new(executeAction: ExecuteLoad,
          canExecuteFunc: CanExecuteLoad);

        UpdatePPECommand = new(executeAction: ExecuteUpdatePPE,
           canExecuteFunc: CanExecuteUpdatePPE);
    }

    private void Clear() => PPE = null;

    private async Task LoadData() =>
        PPEs = await _repository.GetPPEListAsync();

    #endregion
}