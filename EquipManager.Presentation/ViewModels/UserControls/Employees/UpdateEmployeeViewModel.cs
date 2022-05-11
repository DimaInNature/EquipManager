namespace EquipManager.Presentation.ViewModels.UserControls.Employees;

/// <summary> Модель представления для <see cref="UpdateEmployeeView"/>.</summary>
internal sealed class UpdateEmployeeViewModel
    : BaseViewModel, IViewModel<UpdateEmployeeView>
{
    #region Members

    public IList<Employee> Employees
    {
        get => _employees;
        set
        {
            _employees = value is null
                ? new List<Employee>()
                : value;

            OnPropertyChanged(nameof(Employees));
        }
    }

    public Employee? Employee
    {
        get => _employee;
        set
        {
            _employee = value;

            OnPropertyChanged(nameof(Employee));
        }
    }

    #region Commands

    public RelayCommand? LoadCommand { get; private set; }

    public RelayCommand? UpdateEmployeeCommand { get; private set; }

    #endregion

    #region Private

    private IList<Employee> _employees = new List<Employee>();

    private Employee? _employee;

    #endregion

    #region Dependencies

    private readonly IEmployeeFacadeService _repository;

    private readonly IMessageBoxService _messageBox;

    #endregion

    #endregion

    public UpdateEmployeeViewModel(IEmployeeFacadeService repository,
       IMessageBoxService messageBox)
    {
        (_repository, _messageBox) = (repository, messageBox);

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteLoad(object obj) => await LoadData();

    private async void ExecuteUpdateEmployee(object obj)
    {
        if (Employee is null || Employee.EmployeeSizeChart is null) return;

        var employee = Employee.GetBuilder()
           .SetFullName(Employee.Name, Employee.Surname, Employee.Patronymic)
           .SetProfession(Employee.Profession)
           .SetGender(Employee.Gender)
           .SetStructuralDivision(Employee.StructuralDivision)
           .SetHeight(Employee.Height)
           .Build();

        var sizeChart = EmployeeSizeChart.GetBuilder()
            .AddCloth(Employee.EmployeeSizeChart.Cloth)
            .AddHeaddress(Employee.EmployeeSizeChart.Headdress)
            .AddGazMask(Employee.EmployeeSizeChart.GazMask)
            .AddRespirator(Employee.EmployeeSizeChart.Respirator)
            .AddSleeve(Employee.EmployeeSizeChart.Sleeve)
            .AddGlove(Employee.EmployeeSizeChart.Glove)
            .AddShoesSize(Employee.EmployeeSizeChart.Shoes)
            .Build();

        await _repository.UpdateAsync(employeeModel: (employee, sizeChart));

        _messageBox.Show(
            text: LanguageTranslator.Translate(key: "tm_EmployeeSuccessfullyUpdated"),
            caption: LanguageTranslator.Translate(key: "tm_Success"),
            icon: MessageBoxImage.Information);

        Clear();

        await LoadData();
    }

    private bool CanExecuteLoad(object obj) => true;

    private bool CanExecuteUpdateEmployee(object obj)
    {
        if (Employee is null || Employee.EmployeeSizeChart is null) return false;

        string[] textProps = { Employee.Name, Employee.Surname, Employee.Patronymic, Employee.Gender,
            Employee.StructuralDivision, Employee.Profession };

        int?[] digitProps = { Employee.Height, Employee.EmployeeSizeChart.Cloth, Employee.EmployeeSizeChart.GazMask,
            Employee.EmployeeSizeChart.Headdress, Employee.EmployeeSizeChart.Glove, Employee.EmployeeSizeChart.Respirator,
            Employee.EmployeeSizeChart.Sleeve, Employee.EmployeeSizeChart.Shoes };

        return textProps.IsNotNullOrWhiteSpace() && digitProps.IsPositive();
    }

    #endregion

    #region Other Logic

    private void InitializeCommand()
    {
        LoadCommand = new(executeAction: ExecuteLoad,
          canExecuteFunc: CanExecuteLoad);

        UpdateEmployeeCommand = new(executeAction: ExecuteUpdateEmployee,
            canExecuteFunc: CanExecuteUpdateEmployee);
    }

    private void Clear() => Employee = null;

    private async Task LoadData() =>
        Employees = await _repository.GetEmployeeListAsync();

    #endregion
}