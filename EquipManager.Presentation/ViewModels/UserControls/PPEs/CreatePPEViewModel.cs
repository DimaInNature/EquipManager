namespace EquipManager.Presentation.ViewModels.UserControls.PPEs;

/// <summary> Модель представления для <see cref="CreatePPEView"/>.</summary>
internal sealed class CreatePPEViewModel
    : BaseViewModel, IViewModel<CreatePPEView>
{
    #region Members

    #region Properties

    public string Name
    {
        get => _name ?? string.Empty;
        set
        {
            _name = value ?? string.Empty;

            OnPropertyChanged(nameof(Name));
        }
    }

    public string UnitOfMeasurement
    {
        get => _unitOfMeasurement ?? string.Empty;
        set
        {
            _unitOfMeasurement = value ?? string.Empty;

            OnPropertyChanged(nameof(UnitOfMeasurement));
        }
    }

    public int? QuantityOfYear
    {
        get => _quantityOfYear;
        set
        {
            if (value is null) _quantityOfYear = value;
            else
            {
                _quantityOfYear = value >= 0 ? value : null;

                if (_quantityOfYear is null)
                    _messageBox.Show(
                       text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 0.",
                       caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                       icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(QuantityOfYear));
        }
    }

    public string CertificateOfConformity
    {
        get => _certificateOfConformity ?? string.Empty;
        set
        {
            _certificateOfConformity = value ?? string.Empty;

            OnPropertyChanged(nameof(CertificateOfConformity));
        }
    }

    #endregion

    #region Commands

    public RelayCommand? CreatePPECommand { get; private set; }

    #endregion

    #region Private

    private string? _name;

    private string? _unitOfMeasurement;

    private int? _quantityOfYear;

    private string? _certificateOfConformity;

    #endregion

    #region Dependencies

    private readonly IPPEFacadeService _repository;

    private readonly IMessageBoxService _messageBox;

    #endregion

    #endregion

    public CreatePPEViewModel(IPPEFacadeService repository,
        IMessageBoxService messageBox)
    {
        (_repository, _messageBox) = (repository, messageBox);

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteCreatePPE(object obj)
    {
        var ppe = PPE.GetBuilder()
            .SetName(Name)
            .SetQuantityPerYear(QuantityOfYear)
            .SetUnitOfMeasurement(UnitOfMeasurement)
            .SetCertificateOfConformity(CertificateOfConformity)
            .Build();

        await _repository.CreateAsync(entity: ppe);

        _messageBox.Show(
            text: LanguageTranslator.Translate(key: "tm_PPESuccessfullyCreated"),
            caption: LanguageTranslator.Translate(key: "tm_Success"),
            icon: MessageBoxImage.Information);

        Clear();
    }

    private bool CanExecuteCreatePPE(object obj)
    {
        string[] textProps = { Name, UnitOfMeasurement, CertificateOfConformity };

        int?[] digitProps = { QuantityOfYear };

        return textProps.IsNotNullOrWhiteSpace() && digitProps.IsPositive();
    }

    #endregion

    #region Other Logic

    private void InitializeCommand()
    {
        CreatePPECommand = new(executeAction: ExecuteCreatePPE,
            canExecuteFunc: CanExecuteCreatePPE);
    }

    private void Clear()
    {
        Name = UnitOfMeasurement = CertificateOfConformity = string.Empty;

        QuantityOfYear = null;
    }

    #endregion
}