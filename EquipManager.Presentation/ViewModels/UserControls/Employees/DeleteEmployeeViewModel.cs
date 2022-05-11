namespace EquipManager.Presentation.ViewModels.UserControls.Employees;

/// <summary> Модель представления для <see cref="DeleteEmployeeView"/>.</summary>
internal sealed class DeleteEmployeeViewModel
    : BaseViewModel, IViewModel<DeleteEmployeeView>
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

    public RelayCommand? DeleteEmployeeCommand { get; private set; }

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

    public DeleteEmployeeViewModel(IEmployeeFacadeService repository,
       IMessageBoxService messageBox)
    {
        (_repository, _messageBox) = (repository, messageBox);

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteUpdateEmployee(object obj)
    {
        if (Employee is null) return;

        await _repository.DeleteAsync(Employee.Id);

        _messageBox.Show(
            text: LanguageTranslator.Translate(key: "tm_EmployeeSuccessfullyDeleted"),
            caption: LanguageTranslator.Translate(key: "tm_Success"),
            icon: MessageBoxImage.Information);

        Clear();

        await LoadData();
    }

    private async void ExecuteLoad(object obj) => await LoadData();

    private bool CanExecuteUpdateEmployee(object obj) => Employee is not null;

    private bool CanExecuteLoad(object obj) => true;

    #endregion

    #region Other Logic

    private void InitializeCommand()
    {
        LoadCommand = new(executeAction: ExecuteLoad,
          canExecuteFunc: CanExecuteLoad);

        DeleteEmployeeCommand = new(executeAction: ExecuteUpdateEmployee,
            canExecuteFunc: CanExecuteUpdateEmployee);
    }

    private void Clear() => Employee = null;

    private async Task LoadData() =>
        Employees = await _repository.GetEmployeeListAsync();

    #endregion
}