namespace EquipManager.Presentation.ViewModels.UserControls.Employees;

/// <summary> Модель представления для <see cref="ChoiceEmployeeView"/>.</summary>
internal sealed class ChoiceEmployeeViewModel
    : BaseViewModel, IViewModel<ChoiceEmployeeView>
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

    #endregion

    #region Private

    private Employee? _employee;

    private IList<Employee> _employees = new List<Employee>();

    #endregion

    #region Dependencies

    private readonly IEmployeeFacadeService _repository;

    #endregion

    #endregion

    public ChoiceEmployeeViewModel(IEmployeeFacadeService repository)
    {
        _repository = repository;

        InitializeCommand();
    }

    #region Command Logic

    private async void ExecuteLoad(object obj) =>
        Employees = await _repository.GetEmployeeListAsync();

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