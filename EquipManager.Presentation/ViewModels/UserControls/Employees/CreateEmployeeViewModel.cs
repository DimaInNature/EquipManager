namespace EquipManager.Presentation.ViewModels.UserControls.Employees;

/// <summary> Модель представления для <see cref="CreateEmployeeView"/>.</summary>
internal sealed class CreateEmployeeViewModel
    : BaseViewModel, IViewModel<CreateEmployeeView>
{
    #region Members

    #region Properties

    #region Employee

    public string Name
    {
        get => _name ?? string.Empty;
        set
        {
            _name = value ?? string.Empty;

            OnPropertyChanged(nameof(Name));
        }
    }

    public string Surname
    {
        get => _surname ?? string.Empty;
        set
        {
            _surname = value ?? string.Empty;

            OnPropertyChanged(nameof(Surname));
        }
    }

    public string Patronymic
    {
        get => _patronymic ?? string.Empty;
        set
        {
            _patronymic = value ?? string.Empty;

            OnPropertyChanged(nameof(Patronymic));
        }
    }

    public string Gender
    {
        get => _gender ?? string.Empty;
        set
        {
            _gender = value ?? string.Empty;

            OnPropertyChanged(nameof(Gender));
        }
    }

    public string StructuralDivision
    {
        get => _structuralDivision ?? string.Empty;
        set
        {
            _structuralDivision = value ?? string.Empty;

            OnPropertyChanged(nameof(StructuralDivision));
        }
    }

    public string Profession
    {
        get => _profession ?? string.Empty;
        set
        {
            _profession = value ?? string.Empty;

            OnPropertyChanged(nameof(Profession));
        }
    }

    public DateTime? DateOfEmployment
    {
        get => _dateOfEmployment;
        set
        {
            _dateOfEmployment = value;

            OnPropertyChanged(nameof(DateOfEmployment));
        }
    }

    public DateTime? DateOfProfessionChange
    {
        get => _dateOfProfessionChange;
        set
        {
            _dateOfProfessionChange = value;

            OnPropertyChanged(nameof(DateOfProfessionChange));
        }
    }

    public int? Height
    {
        get => _height;
        set
        {
            if (value is null) _height = value;
            else
            {
                _height = value >= 150 && value <= 220 ? value : null;

                if (_height is null)
                    _messageBox.Show(
                        text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 150. {LanguageTranslator.Translate(key: "tm_MaxValue")}: 220.",
                        caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                        icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(Height));
        }
    }

    #endregion

    #region SizeChart

    public int? SizeCloth
    {
        get => _sizeCloth;
        set
        {
            if (value is null) _sizeCloth = value;
            else
            {
                _sizeCloth = value >= 40 && value <= 58 ? value : null;

                if (_sizeCloth is null)
                    _messageBox.Show(
                       text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 40. {LanguageTranslator.Translate(key: "tm_MaxValue")}: 58.",
                       caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                       icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(SizeCloth));
        }
    }

    public int? SizeGazMask
    {
        get => _sizeGazMask;
        set
        {
            if (value is null) _sizeGazMask = value;
            else
            {
                _sizeGazMask = value >= 0 && value <= 4 ? value : null;

                if (_sizeGazMask is null)
                    _messageBox.Show(
                        text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 0. {LanguageTranslator.Translate(key: "tm_MaxValue")}: 4.",
                        caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                        icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(SizeGazMask));
        }
    }

    public int? SizeSleeve
    {
        get => _sizeSleeve;
        set
        {
            if (value is null) _sizeSleeve = value;
            else
            {
                _sizeSleeve = value >= 6 && value <= 9 ? value : null;

                if (_sizeSleeve is null)
                    _messageBox.Show(
                       text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 6. {LanguageTranslator.Translate(key: "tm_MaxValue")}: 9.",
                       caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                       icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(SizeSleeve));
        }
    }

    public int? SizeHeaddress
    {
        get => _sizeHeaddress;
        set
        {
            if (value is null) _sizeHeaddress = value;
            else
            {
                _sizeHeaddress = value >= 54 && value <= 65 ? value : null;

                if (_sizeHeaddress is null)
                    _messageBox.Show(
                       text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 54. {LanguageTranslator.Translate(key: "tm_MaxValue")}: 65.",
                       caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                       icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(SizeHeaddress));
        }
    }

    public int? SizeRespirator
    {
        get => _sizeRespirator;
        set
        {
            if (value is null) _sizeRespirator = value;
            else
            {
                _sizeRespirator = value >= 1 && value <= 3 ? value : null;

                if (_sizeRespirator is null)
                    _messageBox.Show(
                       text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 1. {LanguageTranslator.Translate(key: "tm_MaxValue")}: 3.",
                       caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                       icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(SizeRespirator));
        }
    }

    public int? SizeGlove
    {
        get => _sizeGlove;
        set
        {
            if (value is null) _sizeGlove = value;
            else
            {
                _sizeGlove = value >= 6 && value <= 12 ? value : null;

                if (_sizeGlove is null)
                    _messageBox.Show(
                       text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 6. {LanguageTranslator.Translate(key: "tm_MaxValue")}: 12.",
                       caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                       icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(SizeGlove));
        }
    }

    public int? SizeShoes
    {
        get => _sizeShoes;
        set
        {
            if (value is null) _sizeShoes = value;
            else
            {
                _sizeShoes = value >= 38 && value <= 50 ? value : null;

                if (_sizeShoes is null)
                    _messageBox.Show(
                       text: $"{LanguageTranslator.Translate(key: "tm_MinValue")}: 38. {LanguageTranslator.Translate(key: "tm_MaxValue")}: 50.",
                       caption: LanguageTranslator.Translate(key: "tm_ValidationError"),
                       icon: MessageBoxImage.Warning);
            }

            OnPropertyChanged(nameof(SizeShoes));
        }
    }

    #endregion

    #endregion

    #region Commands

    public RelayCommand? CreateEmployeeCommand { get; private set; }

    #endregion

    #region Private

    #region Employee

    private string? _name;

    private string? _surname;

    private string? _patronymic;

    private string? _gender;

    private string? _structuralDivision;

    private string? _profession;

    private DateTime? _dateOfEmployment;

    private DateTime? _dateOfProfessionChange;

    private int? _height;

    #endregion

    #region SizeChart

    private int? _sizeCloth;

    private int? _sizeGazMask;

    private int? _sizeSleeve;

    private int? _sizeHeaddress;

    private int? _sizeRespirator;

    private int? _sizeGlove;

    private int? _sizeShoes;

    #endregion

    #endregion

    #region Dependencies

    private readonly IEmployeeFacadeService _repository;

    private readonly IMessageBoxService _messageBox;

    #endregion

    #endregion

    public CreateEmployeeViewModel(IEmployeeFacadeService repository,
        IMessageBoxService messageBox)
    {
        (_repository, _messageBox) = (repository, messageBox);

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteCreateEmployee(object obj)
    {
        var employee = Employee.GetBuilder()
            .SetFullName(Name, Surname, Patronymic)
            .SetProfession(Profession)
            .SetGender(Gender)
            .SetStructuralDivision(StructuralDivision)
            .SetHeight(Height)
            .SetDateOfProfessionChange(DateOfProfessionChange)
            .SetDateOfEmployment(DateOfEmployment)
            .Build();

        var sizeChart = EmployeeSizeChart.GetBuilder()
            .AddCloth(SizeCloth)
            .AddHeaddress(SizeHeaddress)
            .AddGazMask(SizeGazMask)
            .AddRespirator(SizeRespirator)
            .AddSleeve(SizeSleeve)
            .AddGlove(SizeGlove)
            .AddShoesSize(SizeShoes)
            .Build();

        await _repository.CreateAsync(employeeModel: (employee, sizeChart));

        _messageBox.Show(
            text: LanguageTranslator.Translate(key: "tm_EmployeeSuccessfullyCreated"),
            caption: LanguageTranslator.Translate(key: "tm_Success"),
            icon: MessageBoxImage.Information);

        Clear();
    }

    private bool CanExecuteCreateEmployee(object obj)
    {
        string[] textProps = { Name, Surname, Patronymic, Gender,
            StructuralDivision, Profession };

        int?[] digitProps = { Height, SizeCloth, SizeGazMask, SizeHeaddress,
            SizeGlove, SizeRespirator, SizeSleeve, SizeShoes };

        return textProps.IsNotNullOrWhiteSpace() && digitProps.IsPositive();
    }

    #endregion

    #region Other Logic

    private void InitializeCommand() =>
        CreateEmployeeCommand = new(executeAction: ExecuteCreateEmployee,
            canExecuteFunc: CanExecuteCreateEmployee);

    private void Clear()
    {
        Name = Surname = Patronymic = Gender =
            StructuralDivision = Profession = string.Empty;

        Height = SizeCloth = SizeGazMask = SizeHeaddress = SizeGlove =
            SizeRespirator = SizeSleeve = SizeShoes = null;

        DateOfEmployment = DateOfProfessionChange = null;
    }

    #endregion
}